using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clempaul.Dreamhost;
using System.Net;
using System.IO;
using System.Xml.Linq;


namespace clempaul
{
    public class DreamhostAPI
    {
        #region Private Variables

        private string username = string.Empty;
        private string apikey = string.Empty;
        private Domain domain = null;
        private DNS dns = null;
        private User user = null;

        #endregion

        #region Constructor

        public DreamhostAPI(string username, string apikey)
        {
            this.username = username;
            this.apikey = apikey;
        }

        #endregion

        #region Accessors

        public Domain Domain
        {
            get
            {
                if (this.domain == null)
                {
                    this.domain = new Domain(this);
                }

                return this.domain;
            }

        }

        public DNS DNS
        {
            get
            {
                if (this.dns == null)
                {
                    this.dns = new DNS(this);
                }

                return this.dns;
            }
        }

        public User User
        {
            get
            {
                if (this.user == null)
                {
                    this.user = new User(this);
                }

                return this.user;
            }
        }

        #endregion

        #region Internal Methods

        internal XDocument SendCommand(string method)
        {
            return this.SendCommand(method, new QueryData[0]);
        }

        internal XDocument SendCommand(string method, QueryData[] parameters)
        {

            XDocument response = this.GetResponse(method, parameters);

            if (!this.ValidResponse(response))
            {
                throw new Exception(GetErrorCode(response));
            }

            return this.GetResponse(method, parameters);
        }

        internal static object ParseXMLElement(XElement element)
        {
            return DreamhostAPI.ParseXMLElement(element, typeof(string));
        }

        internal static object ParseXMLElement(XElement element, Type type)
        {
            if (type.Equals(typeof(bool)))
            {
                if (element == null)
                {
                    return false;
                }
                else
                {
                    return !element.Value.Equals("0") && !element.Value.Equals("no");
                }
            }
            else if (type.Equals(typeof(string)))
            {
                if (element == null)
                {
                    return string.Empty;
                }
                else
                {
                    return element.Value;
                }
            }
            else if (type.Equals(typeof(DateTime)))
            {
                if (element == null)
                {
                    return null;
                }
                else
                {
                    return DateTime.Parse(element.Value);
                }
            }
            else if (type.Equals(typeof(int)))
            {
                if (element == null)
                {
                    return null;
                }
                else
                {
                    return int.Parse(element.Value);
                }
            }
            else if (type.Equals(typeof(double)))
            {
                if (element == null)
                {
                    return null;
                }
                else
                {
                    return double.Parse(element.Value);
                }
            }

            return null;
        }

        internal XDocument GetResponse(string method, QueryData[] parameters)
        {
            string uri = "https://api.dreamhost.com/";

            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(uri);

            wr.Method = "POST";
            wr.ContentType = "application/x-www-form-urlencoded";

            string postdata = string.Empty;

            postdata += "username=" + Uri.EscapeDataString(this.username);
            postdata += "&key=" + Uri.EscapeDataString(this.apikey);
            postdata += "&unique_id=" + Uri.EscapeDataString(Guid.NewGuid().ToString());
            postdata += "&format=xml";
            postdata += "&cmd=" + Uri.EscapeDataString(method);

            foreach (QueryData parameter in parameters)
            {
                postdata += "&" + Uri.EscapeDataString(parameter.Key) + "=" + Uri.EscapeDataString(parameter.Value);
            }

            wr.ContentLength = postdata.Length;
            
            StreamWriter stOut = new StreamWriter(wr.GetRequestStream(),System.Text.Encoding.ASCII);
            stOut.Write(postdata);
            stOut.Close();

            return XDocument.Parse("<response>" + new StreamReader(wr.GetResponse().GetResponseStream()).ReadToEnd() + "</response>");
        }

        internal Boolean ValidResponse(XDocument response)
        {
            var query = from c in response.Elements("response").Elements("result") select c.Value;

            foreach (string result in query)
            {
                if (result == "success")
                {
                    return true;
                }
            }

            return false;
        }

        internal string GetErrorCode(XDocument response)
        {
            var query = from c in response.Elements("response").Elements("data") select c.Value;

            foreach (string result in query)
            {
                return result;
            }

            return string.Empty;
        }

        #endregion

        #region Public Methods

        public IEnumerable<String> ListAccessibleMethods()
        {
            XDocument response = this.SendCommand("api-list_accessible_cmds");

            var cmds = from data in response.Element("response").Elements("data")
                       select data.Element("cmd").Value;

            return cmds;
        }

        #endregion
    }
}

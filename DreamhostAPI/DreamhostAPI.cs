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

        #endregion

        #region Internal Methods

        internal XDocument SendCommand(string method)
        {
            return this.SendCommand(method, new QueryData[0]);
        }

        internal XDocument SendCommand(string method, QueryData[] parameters) {

            XDocument response = this.GetResponse(method, parameters);

            if ( !this.ValidResponse(response) ) 
            {
                throw new Exception(GetErrorCode(response));
            }

            return this.GetResponse(method, parameters);
        }

        internal static object ParseXMLElement(XElement element)
        {
            return DreamhostAPI.ParseXMLElement(element, typeof(string));
        }

        internal static object ParseXMLElement(XElement element, Type type) {
            if ( type.Equals(typeof(bool)) ) {
                if (element == null)
                {
                    return false;
                }
                else
                {
                    return !element.Value.Equals("0") && !element.Value.Equals("no");
                }
            }
            else if ( type.Equals(typeof(string)) ) {
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

            return null;
        }

        internal XDocument GetResponse(string method, QueryData[] parameters)
        {
            string uri = "https://api.dreamhost.com/";
            uri += "?username=" + this.username;
            uri += "&key=" + this.apikey;
            uri += "&unique_id=" + Guid.NewGuid();
            uri += "&format=xml";
            uri += "&cmd=" + method;

            foreach (QueryData parameter in parameters)
            {
                uri += "&" + parameter.Key + "=" + parameter.Value;
            }

            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(uri);
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
    }
}

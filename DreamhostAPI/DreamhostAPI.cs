using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using clempaul.Dreamhost;

namespace clempaul
{
    public class DreamhostAPI
    {
        #region Private Variables

        private string apikey = string.Empty;
        private DomainRequests domain = null;
        private DNSRequests dns = null;
        private UserRequests user = null;
        private MailRequests mail = null;
        private MySQLRequests mysql = null;
        private AnnouncementListRequests announcementlist = null;

        #endregion

        #region Constructor

        public DreamhostAPI(string apikey)
        {
            this.apikey = apikey;
        }

        #endregion

        #region Accessors

        public DomainRequests Domain
        {
            get
            {
                if (this.domain == null)
                {
                    this.domain = new DomainRequests(this);
                }

                return this.domain;
            }

        }

        public DNSRequests DNS
        {
            get
            {
                if (this.dns == null)
                {
                    this.dns = new DNSRequests(this);
                }

                return this.dns;
            }
        }

        public UserRequests User
        {
            get
            {
                if (this.user == null)
                {
                    this.user = new UserRequests(this);
                }

                return this.user;
            }
        }

        public MailRequests Mail
        {
            get
            {
                if (this.mail == null)
                {
                    this.mail = new MailRequests(this);
                }

                return this.mail;
            }
        }

        public MySQLRequests MySQL
        {
            get
            {
                if (this.mysql == null)
                {
                    this.mysql = new MySQLRequests(this);
                }

                return this.mysql;
            }
        }

        public AnnouncementListRequests AnnouncementList
        {
            get
            {
                if (this.announcementlist == null)
                {
                    this.announcementlist = new AnnouncementListRequests(this);
                }

                return this.announcementlist;
            }
        }

        #endregion

        #region Internal Methods

        internal XDocument SendCommand(string method)
        {
            return this.SendCommand(method, new QueryData[0]);
        }

        internal XDocument SendCommand(string method, List<QueryData> parameters)
        {
            return this.SendCommand(method, parameters.ToArray());
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

        internal XDocument GetResponse(string method, QueryData[] parameters)
        {
            string uri = "https://api.dreamhost.com/";

            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(uri);

            wr.Method = "POST";
            wr.ContentType = "application/x-www-form-urlencoded";

            string postdata = string.Empty;

            postdata += "key=" + Uri.EscapeDataString(this.apikey);
            postdata += "&unique_id=" + Uri.EscapeDataString(Guid.NewGuid().ToString());
            postdata += "&format=xml";
            postdata += "&cmd=" + Uri.EscapeDataString(method);

            foreach (QueryData parameter in parameters)
            {
                postdata += "&" + Uri.EscapeDataString(parameter.Key) + "=" + Uri.EscapeDataString(parameter.Value);
            }

            wr.ContentLength = postdata.Length;

            StreamWriter stOut = new StreamWriter(wr.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(postdata);
            stOut.Close();

            return XDocument.Parse(new StreamReader(wr.GetResponse().GetResponseStream()).ReadToEnd());
        }

        internal Boolean ValidResponse(XDocument response)
        {
            var query = from c in response.Elements("dreamhost").Elements("result") select c.Value;

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
            var query = from c in response.Elements("dreamhost").Elements("data") select c.Value;

            foreach (string result in query)
            {
                return result;
            }

            return string.Empty;
        }

        #endregion

        #region api-list_accessible_cmds

        public IEnumerable<String> ListAccessibleMethods()
        {
            XDocument response = this.SendCommand("api-list_accessible_cmds");

            return from data in response.Element("dreamhost").Elements("data")
                       select data.Element("cmd").AsString();
        }

        #endregion
    }
}

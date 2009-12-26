using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;
using System;

namespace clempaul.Dreamhost
{
    public class OneClickRequests
    {
        DreamhostAPI api;

        internal OneClickRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        #region oneclick-list_easy

        public IEnumerable<OneClick> ListEasy()
        {
            XDocument response = api.SendCommand("oneclick-list_easy");

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new OneClick
                   {
                       domain = data.Element("domain").AsString(),
                       type = data.Element("type").AsString(),
                       stamp = data.Element("stamp").AsDateTime()
                   };
        }

        #endregion

        #region oneclick-list_advanced

        public IEnumerable<OneClickAdvanced> ListAdvanced()
        {
            XDocument response = api.SendCommand("oneclick-list_advanced");

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new OneClickAdvanced
                   {
                       url = data.Element("url").AsString(),
                       type = data.Element("type").AsString(),
                       stamp = data.Element("stamp").AsDateTime(),
                       upgradable = data.Element("upgradeable").AsBool()
                   };
        }

        #endregion

        #region oneclick-install_easy

        public OneClickInstall InstallEasy(string domain, string type, string title, string email)
        {
            // Check Parameters

            if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }
            else if (type == null || type == string.Empty)
            {
                throw new Exception("Missing type parameter");
            }
            else if (title == null || title == string.Empty)
            {
                throw new Exception("Missing title parameter");
            }
            else if (email == null || email == string.Empty)
            {
                throw new Exception("Missing email parameter");
            }

            // Construct Request

            List<QueryData> parameters = new List<QueryData>
            {
                new QueryData("domain", domain),
                new QueryData("type", type),
                new QueryData("title", title),
                new QueryData("email", email)
            };

            XDocument response = api.SendCommand("oneclick-install_easy", parameters);

            // Handle Response

            return (from data in response.Element("dreamhost").Elements("data")
                    select new OneClickInstall
                    {
                        admin_password = data.Element("admin_password").AsString(),
                        main_domain = data.Element("main_domain").AsString()
                    }).First();
        }

        #endregion

        #region oneclick-install_advanced

        public void InstallAdvanced(string url, string type, string database)
        {
            // Check Parameters

            if (url == null || url == string.Empty)
            {
                throw new Exception("Missing url parameter");
            }
            else if (type == null || type == string.Empty)
            {
                throw new Exception("Missing type parameter");
            }
            else if (database == null || database == string.Empty)
            {
                throw new Exception("Missing database parameter");
            }

            // Build Request

            List<QueryData> parameters = new List<QueryData>
            {
                new QueryData("url", url),
                new QueryData("type", type),
                new QueryData("database", database)
            };

            api.SendCommand("oneclick-install_advanced", parameters);
        }

        #endregion

        #region oneclick-upgrade

        public void Upgrade(string url)
        {
            // Check Parameters

            if (url == null || url == string.Empty)
            {
                throw new Exception("Missing url parameter");
            }

            // Build Request

            api.SendCommand("oneclick-upgrade", new List<QueryData> { new QueryData("url", url) });
        }

        #endregion

        #region oneclick-upgrade_all

        public IEnumerable<string> UpgradeAll(string type)
        {
            // Check parameter 

            if (type == null || type == string.Empty)
            {
                throw new Exception("Missing type parameter");
            }
            
            XDocument response = api.SendCommand("oneclick-upgrade_all", new List<QueryData> { new QueryData("type", type) });

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select data.Element("url").AsString();
        }

        #endregion

        #region oneclick-list_settings

        public IEnumerable<KeyValuePair<string, string>> ListSettings(string domain)
        {
            // Check parameters

            if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }

            // Send request

            XDocument response = api.SendCommand("oneclick-list_settings", new List<QueryData> { new QueryData("domain", domain) });

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new KeyValuePair<string, string>
                       (data.Element("setting").AsString(), data.Element("value").AsString());
        }

        #endregion

        #region oneclick-set_settings

        public void SetSettings(string domain, string setting, string value)
        {
            // Check Parameters

            if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }
            else if (setting == null || setting == string.Empty)
            {
                throw new Exception("Missing setting parameter");
            }
            else if (value == null || value == string.Empty) 
            {
                throw new Exception("Missing value parameter");
            }

            // Build Request

            List<QueryData> parameters = new List<QueryData>
            {
                new QueryData("domain", domain),
                new QueryData("setting", setting),
                new QueryData("value", value)
            };

            api.SendCommand("oneclick-set_settings", parameters);
        }

        #endregion

        #region oneclick-destroy_easy

        public DestroyResult DestroyEasy(string domain)
        {
            // Check parameters

            if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }

            //Build Request

            XDocument response = api.SendCommand("oneclick-destroy_easy", new List<QueryData> { new QueryData("domain", domain) });

            // Handle Response

            return (from data in response.Element("dreamhost").Elements("data")
                   select new DestroyResult
                   {
                       database = data.Element("database").AsString(),
                       prefix = data.Element("prefix").AsString()
                   }).First();
        }

        #endregion

        #region oneclick-destroy_advanced

        public void DestroyAdvanced(string url, bool deletefiles)
        {
            // Check parameters

            if (url == null || url == string.Empty)
            {
                throw new Exception("Missing url parameter");
            }

            // Build Request

            List<QueryData> parameters = new List<QueryData>
            {
                new QueryData("url", url),
                new QueryData("deletefiles", deletefiles.AsBit())
            };

            api.SendCommand("oneclick-destroy_advanced", parameters);
        }

        #endregion
    }
}

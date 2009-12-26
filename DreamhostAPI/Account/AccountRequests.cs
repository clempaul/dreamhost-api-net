using System.Linq;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;
using System.Collections.Generic;

namespace clempaul.Dreamhost
{
    public class AccountRequests
    {
        DreamhostAPI api = null;

        internal AccountRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        #region account-domain_usage

        public IEnumerable<DomainUsage> DomainUsage()
        {
            XDocument response = api.SendCommand("account-domain_usage");

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new DomainUsage
                   {
                       domain = data.Element("domain").AsString(),
                       type = data.Element("type").AsString(),
                       bw = data.Element("bw").AsInt()
                   };
        }

        #endregion

        #region account-status

        public IEnumerable<KeyValuePair<string,XElement>> Status() 
        {
            XDocument response = api.SendCommand("account-status");

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new KeyValuePair<string, XElement>
                       (data.Element("key").AsString(), data.Element("value"));
        }

        #endregion

        #region account-user_usage

        public IEnumerable<UserUsage> UserUsage()
        {
            XDocument response = api.SendCommand("account-user_usage");

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new UserUsage
                   {
                       user = data.Element("user").AsString(),
                       disk = data.Element("disk").AsDouble(),
                       disk_as_of = data.Element("disk_as_of").AsDateTime(),
                       bw = data.Element("bw").AsDouble()
                   };
        }

        #endregion
    }
}

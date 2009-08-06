using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clempaul.Dreamhost.ResponseData;
using System.Xml.Linq;

namespace clempaul.Dreamhost
{
    class PSRequests
    {
        private DreamhostAPI api;

        internal PSRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        public void AddPS(string type, string movedata)
        {
            this.AddPS(null, type, movedata);
        }

        public void AddPS(string account_id, string type, string movedata)
        {
            HashSet<QueryData> parameters = new HashSet<QueryData>();

            parameters.Add(new QueryData("type", type));
            parameters.Add(new QueryData("movedata", movedata));

            if (account_id != null)
            {
                parameters.Add(new QueryData("account_id", account_id));
            }

            api.SendCommand("dreamhost_ps-add_ps", parameters.ToArray<QueryData>());
        }

        public IEnumerable<PendingPS> ListPendingPS()
        {
            XDocument response = api.SendCommand("dreamhost_ps-list_pending_ps");

            return from data in response.Element("response").Elements("data")
                   select new PendingPS
                   {
                       account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                       ip = (string)DreamhostAPI.ParseXMLElement(data.Element("ip")),
                       stamp = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("stamp"), typeof(DateTime)),
                       type = (string)DreamhostAPI.ParseXMLElement(data.Element("type"))
                   };

        }

        public IEnumerable<PendingPS> RemovePendingPS()
        {
            XDocument response = api.SendCommand("dreamhost_ps-remove_pending_ps");

            return from data in response.Element("response").Elements("data")
                   select new PendingPS
                   {
                       account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                       ip = (string)DreamhostAPI.ParseXMLElement(data.Element("ip")),
                       stamp = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("stamp"), typeof(DateTime)),
                       type = (string)DreamhostAPI.ParseXMLElement(data.Element("type"))
                   };
        }

        public IEnumerable<ActivePS> ListPS()
        {
            XDocument response = api.SendCommand("dreamhost_ps-list_ps");

            return from data in response.Element("response").Elements("data")
                   select new ActivePS
                   {
                       account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                       memory_mb = (int)DreamhostAPI.ParseXMLElement(data.Element("memory_mb"), typeof(int)),
                       ps = (string)DreamhostAPI.ParseXMLElement(data.Element("ps")),
                       start_date = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("start_date"), typeof(DateTime)),
                       type = (string)DreamhostAPI.ParseXMLElement(data.Element("type"))
                   };
        }

        public PSSettings ListSettings(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_settings", parameters);

            PSSettings result = new PSSettings();

            foreach (XElement data in response.Element("response").Elements("data"))
            {
                result.set((string)DreamhostAPI.ParseXMLElement(data.Element("setting")), (string)DreamhostAPI.ParseXMLElement(data.Element("value")));
            }

            return result;

        }

        public void SetSettings(string ps, PSSettings Settings)
        {
            List<QueryData> parameters = new List<QueryData>();

            Dictionary<string, string> settings = Settings.getValues();

            string[] Keys = settings.Keys.ToArray<string>();
            string[] Values = settings.Values.ToArray<string>();

            for (int i = 0; i < settings.Count; i++)
            {
                parameters.Add(new QueryData(Keys[i], Values[i]));
            }

            api.SendCommand("dreamhost_ps-set_settings", parameters.ToArray());
        }

        public IEnumerable<PSSize> ListSizeHistory(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_ps", parameters);

            return from data in response.Element("response").Elements("data")
                   select new PSSize
                   {
                       stamp = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("stamp"), typeof(DateTime)),
                       memory_mb = (int)DreamhostAPI.ParseXMLElement(data.Element("memory_mb"), typeof(int)),
                       period_seconds = (int)DreamhostAPI.ParseXMLElement(data.Element("period_seconds"), typeof(int)),
                       period_cost = (double)DreamhostAPI.ParseXMLElement(data.Element("period_cost"), typeof(double)),
                       monthly_cost = (double)DreamhostAPI.ParseXMLElement(data.Element("monthly_cost"), typeof(double))
                   };
        }

        public void SetSize(string ps, int size)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps),
                                         new QueryData("size", size.ToString())
                                     };

            api.SendCommand("dreamhost_ps-set_size", parameters);
        }

        public IEnumerable<DateTime> ListRebootHistory(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_ps", parameters);

            List<DateTime> result = new List<DateTime>();

            foreach (XElement data in response.Element("response").Elements("data"))
            {
                result.Add((DateTime)DreamhostAPI.ParseXMLElement(data.Element("stamp"), typeof(DateTime)));
            }

            return result;
        }

        public void Reboot(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
                                     };

            api.SendCommand("dreamhost_ps-reboot", parameters);
        }

        public IEnumerable<PSUsage> ListUsage(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_ps", parameters);

            return from data in response.Element("response").Elements("data")
                   select new PSUsage
                   {
                       stamp = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("stamp"), typeof(DateTime)),
                       memory_mb = (int)DreamhostAPI.ParseXMLElement(data.Element("memory_mb"), typeof(int)),
                       load = (double)DreamhostAPI.ParseXMLElement(data.Element("load"), typeof(double))
                   };
        }
    }
}

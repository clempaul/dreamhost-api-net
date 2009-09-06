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

            return from data in response.Element("dreamhost").Elements("data")
                   select new PendingPS
                   {
                       account_id = data.Element("account_id").AsString(),
                       ip = data.Element("ip").AsString(),
                       stamp = data.Element("stamp").AsDateTime(),
                       type = data.Element("type").AsString()
                   };

        }

        public IEnumerable<PendingPS> RemovePendingPS()
        {
            XDocument response = api.SendCommand("dreamhost_ps-remove_pending_ps");

            return from data in response.Element("dreamhost").Elements("data")
                   select new PendingPS
                   {
                       account_id = data.Element("account_id").AsString(),
                       ip = data.Element("ip").AsString(),
                       stamp = data.Element("stamp").AsDateTime(),
                       type = data.Element("type").AsString()
                   };
        }

        public IEnumerable<ActivePS> ListPS()
        {
            XDocument response = api.SendCommand("dreamhost_ps-list_ps");

            return from data in response.Element("dreamhost").Elements("data")
                   select new ActivePS
                   {
                       account_id = data.Element("account_id").AsString(),
                       memory_mb = data.Element("memory_mb").AsInt(),
                       ps = data.Element("ps").AsString(),
                       start_date = data.Element("start_date").AsDateTime(),
                       type = data.Element("type").AsString()
                   };
        }

        public PSSettings ListSettings(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_settings", parameters);

            PSSettings result = new PSSettings();

            foreach (XElement data in response.Element("dreamhost").Elements("data"))
            {
                result.set(data.Element("setting").AsString(), data.Element("value").AsString());
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

            return from data in response.Element("dreamhost").Elements("data")
                   select new PSSize
                   {
                       stamp = data.Element("stamp").AsDateTime(),
                       memory_mb = data.Element("memory_mb").AsInt(),
                       period_seconds = data.Element("period_seconds").AsInt(),
                       period_cost = data.Element("period_cost").AsDouble(),
                       monthly_cost = data.Element("monthly_cost").AsDouble()
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

            foreach (XElement data in response.Element("dreamhost").Elements("data"))
            {
                result.Add(data.Element("stamp").AsDateTime());
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

            return from data in response.Element("dreamhost").Elements("data")
                   select new PSUsage
                   {
                       stamp = data.Element("stamp").AsDateTime(),
                       memory_mb = data.Element("memory_mb").AsInt(),
                       load = data.Element("load").AsDouble()
                   };
        }
    }
}

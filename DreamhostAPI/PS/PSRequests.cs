using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    class PSRequests
    {
        private DreamhostAPI api;

        internal PSRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        #region dreamhost_ps-add_ps

        public void AddPS(string account_id, string type, bool? movedata)
        {
            // Check parameters

            if (type == null || type == string.Empty)
            {
                throw new Exception("Missing type parameter");
            }
            else if (type == "web" && movedata == null)
            {
                throw new Exception("Missing movedata parameter");
            }

            // Build request

            List<QueryData> parameters = new List<QueryData>();

            if (account_id != null && account_id != string.Empty)
            {
                parameters.Add(new QueryData("account_id", account_id));
            }

            parameters.Add(new QueryData("type", type));

            if (movedata != null)
            {
                parameters.Add(new QueryData("movedata", movedata.Asyesno()));
            }

            api.SendCommand("dreamhost_ps-add_ps", parameters);
        }

        /*
         * Overloads
         */

        public void AddPS(string type)
        {
            this.AddPS(null, type, null);
        }

        public void AddPS(string type, bool movedata)
        {
            this.AddPS(null, type, movedata);
        }

        public void AddPS(string account_id, string type)
        {
            this.AddPS(account_id, type, null);
        }

        #endregion

        #region dreamhost_ps-list_pending_ps

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

        #endregion

        #region dreamhost_ps-remove_pending_ps

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

        #endregion

        #region dreamhost_ps-list_ps

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

        #endregion

        #region dreamhost_ps-list_settings

        public PSSettings ListSettings(string ps)
        {
            // Check parameters

            if (ps == null || ps == string.Empty)
            {
                throw new Exception("Missing ps parameter");
            }

            // Build request

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

        #endregion

        #region dreamhost_ps-set_settings

        public void SetSettings(string ps, PSSettings Settings)
        {
            // Check parameters

            if (ps == null || ps == string.Empty)
            {
                throw new Exception("Missing ps parameter");
            }

            // Build request

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

        #endregion

        #region dreamhost_ps-list_size_history

        public IEnumerable<PSSize> ListSizeHistory(string ps)
        {
            // Check parameters

            if (ps == null || ps == string.Empty)
            {
                throw new Exception("Missing ps parameter");
            }

            // Build request

            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_size_history", parameters);

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

        #endregion

        #region dreamhost_ps-set_size

        public void SetSize(string ps, int size)
        {
            // Check parameters

            if (ps == null || ps == string.Empty)
            {
                throw new Exception("Missing ps parameter");
            }
            else if (size < 150 || size > 4000)
            {
                throw new Exception("Size out of range");
            }

            // Build request

            QueryData[] parameters = {
                                         new QueryData("ps", ps),
                                         new QueryData("size", size.ToString())
                                     };

            api.SendCommand("dreamhost_ps-set_size", parameters);
        }

        #endregion

        #region dreamhost_ps-list_reboot_history

        public IEnumerable<DateTime> ListRebootHistory(string ps)
        {
            QueryData[] parameters = {
                                         new QueryData("ps", ps)
            };

            XDocument response = api.SendCommand("dreamhost_ps-list_reboot_history", parameters);

            List<DateTime> result = new List<DateTime>();

            foreach (XElement data in response.Element("dreamhost").Elements("data"))
            {
                result.Add(data.Element("stamp").AsDateTime());
            }

            return result;
        }

        #endregion

        #region dreamhost_ps-reboot

        public void Reboot(string ps)
        {
            // Check parameters

            if (ps == null || ps == string.Empty)
            {
                throw new Exception("Missing ps parameter");
            }

            // Construct request

            QueryData[] parameters = {
                                         new QueryData("ps", ps)
                                     };

            api.SendCommand("dreamhost_ps-reboot", parameters);
        }

        #endregion

        #region dreamhost_ps-list_usage

        public IEnumerable<PSUsage> ListUsage(string ps)
        {
            // Check parameters

            if (ps == null || ps == string.Empty)
            {
                throw new Exception("Missing ps parameter");
            }

            // Build request

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

        #endregion
    }
}

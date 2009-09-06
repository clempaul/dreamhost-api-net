using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    public class MailRequests
    {
        private DreamhostAPI api;

        internal MailRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        public IEnumerable<MailFilter> ListFilters()
        {
            XDocument response = api.SendCommand("mail-list_filters");

            var users = from data in response.Element("dreamhost").Elements("data")
                        select new MailFilter
                        {
                            account_id = data.Element("account_id").AsString(),
                            address = data.Element("address").AsString(),
                            rank = data.Element("rank").AsInt(),
                            filter = data.Element("filter").AsString(),
                            filter_on = data.Element("filter_on").AsString(),
                            action = data.Element("action").AsString(),
                            action_value = data.Element("action_value").AsString(),
                            contains = data.Element("contains").AsBool(),
                            stop = data.Element("stop").AsBool()
                        };

            return users;
        }


        public void AddFilter(string address, string filter_on, string filter, string action, string action_value, string contains, string stop, string rank)
        {
            QueryData[] parameters = {
                                         new QueryData("address", address),
                                         new QueryData("filter_on", filter_on),
                                         new QueryData("filter", filter),
                                         new QueryData("action", action),
                                         new QueryData("action_value", action_value),
                                         new QueryData("contains", contains),
                                         new QueryData("stop", stop),
                                         new QueryData("rank", rank)
                                     };

            api.SendCommand("mail-add_filter", parameters);
        }

        public void RemoveFilter(string address, string filter_on, string filter, string action, string action_value, string contains, string stop, string rank)
        {
            QueryData[] parameters = {
                                         new QueryData("address", address),
                                         new QueryData("filter_on", filter_on),
                                         new QueryData("filter", filter),
                                         new QueryData("action", action),
                                         new QueryData("action_value", action_value),
                                         new QueryData("contains", contains),
                                         new QueryData("stop", stop),
                                         new QueryData("rank", rank)
                                     };

            api.SendCommand("mail-remove_filter", parameters);
        }
    }
}

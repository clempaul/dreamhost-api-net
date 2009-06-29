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

            var users = from data in response.Element("response").Elements("data")
                        select new MailFilter
                        {
                            account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                            address = (string)DreamhostAPI.ParseXMLElement(data.Element("address")),
                            rank = (int)DreamhostAPI.ParseXMLElement(data.Element("rank"), typeof(int)),
                            filter = (string)DreamhostAPI.ParseXMLElement(data.Element("filter")),
                            filter_on = (string)DreamhostAPI.ParseXMLElement(data.Element("filter_on")),
                            action = (string)DreamhostAPI.ParseXMLElement(data.Element("action")),
                            action_value = (string)DreamhostAPI.ParseXMLElement(data.Element("action_value")),
                            contains = (bool)DreamhostAPI.ParseXMLElement(data.Element("contains"), typeof(bool)),
                            stop = (bool)DreamhostAPI.ParseXMLElement(data.Element("stop"), typeof(bool)),
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

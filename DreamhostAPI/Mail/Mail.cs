using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace clempaul.Dreamhost
{
    public class Mail
    {
        private DreamhostAPI api;

        internal Mail(DreamhostAPI api)
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
    }
}

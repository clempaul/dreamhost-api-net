using System;
using System.Collections.Generic;
using System.Linq;
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

        #region mail-list_filters

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

        #endregion

        #region mail-add_filter

        public void AddFilter(MailFilter filter)
        {
            // Check parameters

            if (filter.address == null || filter.address == string.Empty)
            {
                throw new Exception("Missing address parameter");
            }
            else if (filter.filter_on == null || filter.filter_on == string.Empty)
            {
                throw new Exception("Missing filter_on parameter");
            }
            else if (filter.filter == null || filter.filter == string.Empty)
            {
                throw new Exception("Missing filter parameter");
            }
            else if (filter.action == null || filter.action == string.Empty)
            {
                throw new Exception("Missing action parameter");
            }
            else if ((filter.action != "delete" && filter.action != "and" && filter.action != "or") && (filter.action_value == null || filter.action_value == string.Empty))
            {
                throw new Exception("Missing action_value parameter");
            }

            // Construct Request

            List<QueryData> parameters = new List<QueryData>();

            parameters.Add(new QueryData("address", filter.address));
            parameters.Add(new QueryData("filter_on", filter.filter_on));
            parameters.Add(new QueryData("filter", filter.filter));
            parameters.Add(new QueryData("action", filter.action));

            if (filter.action_value != null && filter.action_value != string.Empty)
            {
                parameters.Add(new QueryData("action_value", filter.action_value));
            }

            if (filter.contains != null)
            {
                parameters.Add(new QueryData("contains", filter.contains.Asyesno()));
            }

            if (filter.stop != null)
            {
                parameters.Add(new QueryData("stop", filter.stop.Asyesno()));
            }

            if (filter.rank != null)
            {
                parameters.Add(new QueryData("rank", filter.rank.ToString()));
            }

            api.SendCommand("mail-add_filter", parameters);
        }

        #endregion

        #region mail-remove_filter

        public void RemoveFilter(MailFilter filter)
        {
            // Check parameters

            if (filter.address == null || filter.address == string.Empty)
            {
                throw new Exception("Missing address parameter");
            }
            else if (filter.filter_on == null || filter.filter_on == string.Empty)
            {
                throw new Exception("Missing filter_on parameter");
            }
            else if (filter.filter == null || filter.filter == string.Empty)
            {
                throw new Exception("Missing filter parameter");
            }
            else if (filter.action == null || filter.action == string.Empty)
            {
                throw new Exception("Missing action parameter");
            }
            else if ((filter.action != "delete") && (filter.action_value == null || filter.action_value == string.Empty))
            {
                throw new Exception("Missing action_value parameter");
            }
            else if (filter.contains == null)
            {
                throw new Exception("Missing contains parameter");
            }
            else if (filter.stop == null)
            {
                throw new Exception("Missing stop parameter");
            }
            else if (filter.rank == null)
            {
                throw new Exception("Missing rank parameter");
            }

            // Construct Request

            List<QueryData> parameters = new List<QueryData>();

            parameters.Add(new QueryData("address", filter.address));
            parameters.Add(new QueryData("filter_on", filter.filter_on));
            parameters.Add(new QueryData("filter", filter.filter));
            parameters.Add(new QueryData("action", filter.action));

            if (filter.action_value != null && filter.action_value != string.Empty)
            {
                parameters.Add(new QueryData("action_value", filter.action_value));
            }

            parameters.Add(new QueryData("contains", filter.contains.Asyesno()));
            parameters.Add(new QueryData("stop", filter.stop.Asyesno()));
            parameters.Add(new QueryData("rank", filter.rank.ToString()));

            api.SendCommand("mail-remove_filter", parameters);
        }

        #endregion

    }
}

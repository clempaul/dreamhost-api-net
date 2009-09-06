using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    public class AnnouncementListRequests
    {
        DreamhostAPI api;

        internal AnnouncementListRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        public IEnumerable<AnnouncementList> ListLists()
        {
            XDocument response = api.SendCommand("announcement_list-list_lists");

            var lists = from data in response.Element("dreamhost").Elements("data")
                        select new AnnouncementList
                        {
                            account_id = data.Element("account_id").AsString(),
                            listname = data.Element("listname").AsString(),
                            domain = data.Element("domain").AsString(),
                            name = data.Element("name").AsString(),
                            start_date = data.Element("start_date").AsDateTime(),
                            max_bounces = data.Element("max_bounces").AsInt(),
                            num_subscribers = data.Element("num_subscribers").AsInt()
                        };

            return lists;
        }

        public IEnumerable<AnnouncementListSubscriber> ListSubscribers(string listname, string domain)
        {
            QueryData[] parameters = {
                                         new QueryData("listname", listname),
                                         new QueryData("domain", domain)
                                     };

            XDocument response = api.SendCommand("announcement_list-list_subscribers", parameters);

            var subscribers = from data in response.Element("dreamhost").Elements("data")
                              select new AnnouncementListSubscriber
                              {
                                  email = data.Element("email").AsString(),
                                  confirmed = data.Element("confirmed").AsBool(),
                                  subscribe_date = data.Element("subscribe_date").AsDateTime(),
                                  name = data.Element("name").AsString(),
                                  num_bounces = data.Element("num_bounces").AsInt()
                              };

            return subscribers;
        }

        public void AddSubscriber(string listname, string domain, string email, string name)
        {
            QueryData[] parameters = {
                                         new QueryData("listname", listname),
                                         new QueryData("domain", domain),
                                         new QueryData("email", email),
                                         new QueryData("name", name)
                                     };

            api.SendCommand("announcement_list-add_subscriber", parameters);
        }

        public void RemoveSubscriber(string listname, string domain, string email)
        {
            QueryData[] parameters = {
                                         new QueryData("listname", listname),
                                         new QueryData("domain", domain),
                                         new QueryData("email", email)
                                     };

            api.SendCommand("announcement_list-remove_subscriber", parameters);
        }

        public void PostAnnouncement(string listname, string domain, string subject, string message, string name, string stamp, string charset, string type, string duplicate_ok)
        {
            QueryData[] parameters = {
                                         new QueryData("listname", listname),
                                         new QueryData("domain", domain),
                                         new QueryData("subject", subject),
                                         new QueryData("message", message),
                                         new QueryData("name", name),
                                         new QueryData("stamp", stamp),
                                         new QueryData("charset", charset),
                                         new QueryData("type", type),
                                         new QueryData("duplicate_ok", duplicate_ok)
                                     };

            api.SendCommand("announcement_list-post_announcement", parameters);
        }
    }
}

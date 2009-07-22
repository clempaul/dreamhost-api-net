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

            var lists = from data in response.Element("response").Elements("data")
                        select new AnnouncementList
                        {
                            account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                            listname = (string)DreamhostAPI.ParseXMLElement(data.Element("listname")),
                            domain = (string)DreamhostAPI.ParseXMLElement(data.Element("domain")),
                            name = (string)DreamhostAPI.ParseXMLElement(data.Element("name")),
                            start_date = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("start_date"), typeof(DateTime)),
                            max_bounces = (int)DreamhostAPI.ParseXMLElement(data.Element("max_bounces"), typeof(int)),
                            num_subscribers = (int)DreamhostAPI.ParseXMLElement(data.Element("num_subscribers"), typeof(int))
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

            var subscribers = from data in response.Element("response").Elements("data")
                              select new AnnouncementListSubscriber
                              {
                                  email = (string)DreamhostAPI.ParseXMLElement(data.Element("email")),
                                  confirmed = (bool)DreamhostAPI.ParseXMLElement(data.Element("confirmed"), typeof(bool)),
                                  subscribe_date = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("subscribe_date"), typeof(DateTime)),
                                  name = (string)DreamhostAPI.ParseXMLElement(data.Element("name")),
                                  num_bounces = (int)DreamhostAPI.ParseXMLElement(data.Element("num_bounces"), typeof(int))
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

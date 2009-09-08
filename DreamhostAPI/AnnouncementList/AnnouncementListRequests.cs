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

        #region announcement_list-list_lists

        public IEnumerable<AnnouncementList> ListLists()
        {
            XDocument response = api.SendCommand("announcement_list-list_lists");

            return from data in response.Element("dreamhost").Elements("data")
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
        }

        #endregion

        #region announcement_list-list_subscribers

        public IEnumerable<AnnouncementListSubscriber> ListSubscribers(string listname, string domain)
        {
            // Check parameters

            if (listname == string.Empty || listname == null)
            {
                throw new Exception("Missing listname parameter");
            }
            else if (domain == string.Empty || domain == null)
            {
                throw new Exception("Missing domain parameter");
            }

            // Construct Request

            QueryData[] parameters = {
                                         new QueryData("listname", listname),
                                         new QueryData("domain", domain)
                                     };

            XDocument response = api.SendCommand("announcement_list-list_subscribers", parameters);

            // Handle Response

            return from data in response.Element("dreamhost").Elements("data")
                   select new AnnouncementListSubscriber
                   {
                       email = data.Element("email").AsString(),
                       confirmed = data.Element("confirmed").AsBool(),
                       subscribe_date = data.Element("subscribe_date").AsDateTime(),
                       name = data.Element("name").AsString(),
                       num_bounces = data.Element("num_bounces").AsInt()
                   };
        }

        /*
         * Overloads
         */

        public IEnumerable<AnnouncementListSubscriber> ListSubscribers(AnnouncementList list)
        {
            return this.ListSubscribers(list.listname, list.domain);
        }

        #endregion

        #region announcement_list-add_subscriber

        public void AddSubscriber(string listname, string domain, string email, string name)
        {
            // Check parameters

            if (listname == null || listname == string.Empty)
            {
                throw new Exception("Missing listname parameter");
            }
            else if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }
            else if (email == null || email == string.Empty)
            {
                throw new Exception("Missing email parameter");
            }

            // Build request

            List<QueryData> parameters = new List<QueryData>();

            parameters.Add(new QueryData("listname", listname));
            parameters.Add(new QueryData("domain", domain));
            parameters.Add(new QueryData("email", email));

            if (name != null && name != string.Empty)
            {
                parameters.Add(new QueryData("name", name));
            }

            api.SendCommand("announcement_list-add_subscriber", parameters);
        }

        /*
         * Overloads
         */

        public void AddSubscriber(string listname, string domain, string email)
        {
            this.AddSubscriber(listname, domain, email, null);
        }

        public void AddSubscriber(AnnouncementList list, string email, string name)
        {
            this.AddSubscriber(list.listname, list.domain, email, name);
        }

        public void AddSubscriber(AnnouncementList list, string email)
        {
            this.AddSubscriber(list.listname, list.domain, email, null);
        }

        #endregion

        #region announcement_list-remove_subscriber

        public void RemoveSubscriber(string listname, string domain, string email)
        {
            // Check parameters

            if (listname == null || listname == string.Empty)
            {
                throw new Exception("Missing listname parameter");
            }
            else if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }
            else if (email == null || email == string.Empty)
            {
                throw new Exception("Missing email parameter");
            }

            // Build request

            QueryData[] parameters = {
                                         new QueryData("listname", listname),
                                         new QueryData("domain", domain),
                                         new QueryData("email", email)
                                     };

            api.SendCommand("announcement_list-remove_subscriber", parameters);
        }

        /*
         * Overloads
         */

        public void RemoveSubscriber(AnnouncementList list, string email)
        {
            this.RemoveSubscriber(list.listname, list.domain, email);
        }

        public void RemoveSubscriber(AnnouncementList list, AnnouncementListSubscriber subscriber)
        {
            this.RemoveSubscriber(list.listname, list.domain, subscriber.email);
        }

        public void RemoveSubscriber(string listname, string domain, AnnouncementListSubscriber subscriber)
        {
            this.RemoveSubscriber(listname, domain, subscriber.email);
        }

        #endregion

        #region announcement_list-post_announcement

        public void PostAnnouncement(string listname, string domain, string name, Announcement announcement)
        {
            // Check parameters

            if (listname == null || listname == string.Empty)
            {
                throw new Exception("Missing listname parameter");
            }
            else if (domain == null || domain == string.Empty)
            {
                throw new Exception("Missing domain parameter");
            }
            else if (announcement.message == null || announcement.message == string.Empty)
            {
                throw new Exception("Missing message parameter");
            }
            else if (name == null || name == string.Empty)
            {
                throw new Exception("Missing name parameter");
            }

            // Build request

            List<QueryData> parameters = new List<QueryData>();

            parameters.Add(new QueryData("listname", listname));
            parameters.Add(new QueryData("domain", domain));

            if (announcement.subject != null && announcement.subject != string.Empty)
            {
                parameters.Add(new QueryData("subject", announcement.subject));
            }

            parameters.Add(new QueryData("message", announcement.message));
            parameters.Add(new QueryData("name", name));

            if (announcement.stamp != null)
            {
                parameters.Add(new QueryData("stamp", announcement.stamp.AsYYYYMMDD()));
            }

            if (announcement.charset != null && announcement.charset != string.Empty)
            {
                parameters.Add(new QueryData("charset", announcement.charset));
            }

            if (announcement.type != null && announcement.type != string.Empty)
            {
                parameters.Add(new QueryData("type", announcement.type));
            }

            if (announcement.duplicate_ok != null)
            {
                parameters.Add(new QueryData("duplicate_ok", announcement.duplicate_ok.AsBit()));
            }

            api.SendCommand("announcement_list-post_announcement", parameters);

        }

        /*
         * Overloads
         */

        public void PostAnnouncement(AnnouncementList list, Announcement announcement)
        {
            this.PostAnnouncement(list.listname, list.domain, list.name, announcement);
        }
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class AnnouncementList
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _listname;

        public string listname
        {
            get { return _listname; }
            set { _listname = value; }
        }

        private string _domain;

        public string domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private DateTime _start_date;

        public DateTime start_date
        {
            get { return _start_date; }
            set { _start_date = value; }
        }

        private int _max_bounces;

        public int max_bounces
        {
            get { return _max_bounces; }
            set { _max_bounces = value; }
        }

        private int _num_subscribers;

        public int num_subscribers
        {
            get { return _num_subscribers; }
            set { _num_subscribers = value; }
        }
    }
}

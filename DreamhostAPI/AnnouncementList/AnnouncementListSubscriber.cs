using System;

namespace clempaul.Dreamhost.ResponseData
{
    public class AnnouncementListSubscriber
    {
        private string _email = string.Empty;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private bool _confirmed;

        public bool confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }

        private DateTime _subscribe_date;

        public DateTime subscribe_date
        {
            get { return _subscribe_date; }
            set { _subscribe_date = value; }
        }

        private string _name = string.Empty;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _num_bounces;

        public int num_bounces
        {
            get { return _num_bounces; }
            set { _num_bounces = value; }
        }

    }
}

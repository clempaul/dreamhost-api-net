using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class MailFilter
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _address;

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        private int _rank;

        public int rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private string _filter;

        public string filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        private string _filter_on;

        public string filter_on
        {
            get { return _filter_on; }
            set { _filter_on = value; }
        }

        private string _action;

        public string action
        {
            get { return _action; }
            set { _action = value; }
        }

        private string _action_value;

        public string action_value
        {
            get { return _action_value; }
            set { _action_value = value; }
        }

        private bool? _contains = null;

        public bool? contains
        {
            get { return _contains; }
            set { _contains = value; }
        }

        private bool? _stop = null;

        public bool? stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

    }
}

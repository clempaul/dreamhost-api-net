using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class DBHostname
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _domain;

        public string domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        private string _home;

        public string home
        {
            get { return _home; }
            set { _home = value; }
        }
    }
}

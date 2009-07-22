using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class DB
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _db;

        public string db
        {
            get { return _db; }
            set { _db = value; }
        }

        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _home;

        public string home
        {
            get { return _home; }
            set { _home = value; }
        }

        private double _disk_usage_mb;

        public double disk_usage_mb
        {
            get { return _disk_usage_mb; }
            set { _disk_usage_mb = value; }
        }
    }
}

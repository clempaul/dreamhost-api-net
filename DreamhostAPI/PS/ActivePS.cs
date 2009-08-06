using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    class ActivePS
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _ps;

        public string ps
        {
            get { return _ps; }
            set { _ps = value; }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _memory_mb;

        public int memory_mb
        {
            get { return _memory_mb; }
            set { _memory_mb = value; }
        }

        private DateTime _start_date;

        public DateTime start_date
        {
            get { return _start_date; }
            set { _start_date = value; }
        }

    }
}

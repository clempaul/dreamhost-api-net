using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    class PendingPS
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _ip;

        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private DateTime _stamp;

        public DateTime stamp
        {
            get { return _stamp; }
            set { _stamp = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class UserUsage
    {
        private string _user;

        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        private double _disk;

        public double disk
        {
            get { return _disk; }
            set { _disk = value; }
        }

        private DateTime _disk_as_of;

        public DateTime disk_as_of
        {
            get { return _disk_as_of; }
            set { _disk_as_of = value; }
        }

        private double _bw;

        public double bw
        {
            get { return _bw; }
            set { _bw = value; }
        }
    }
}

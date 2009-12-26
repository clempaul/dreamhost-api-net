using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class OneClick
    {
        private string _domain;

        public string domain
        {
            get { return _domain; }
            set { _domain = value; }
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

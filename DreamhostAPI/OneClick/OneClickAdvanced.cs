using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class OneClickAdvanced
    {
        private string _url;

        public string url
        {
            get { return _url; }
            set { _url = value; }
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

        private bool _upgradable;

        public bool upgradable
        {
            get { return _upgradable; }
            set { _upgradable = value; }
        }

    }
}

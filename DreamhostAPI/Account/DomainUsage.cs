using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class DomainUsage
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

        private int _bw;

        public int bw
        {
            get { return _bw; }
            set { _bw = value; }
        }
    }
}

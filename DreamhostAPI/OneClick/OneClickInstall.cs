using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class OneClickInstall
    {
        private string _admin_password;

        public string admin_password
        {
            get { return _admin_password; }
            set { _admin_password = value; }
        }

        private string _main_domain;

        public string main_domain
        {
            get { return _main_domain; }
            set { _main_domain = value; }
        }
    }
}

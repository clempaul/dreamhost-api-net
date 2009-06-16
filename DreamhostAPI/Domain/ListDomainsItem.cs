using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost
{
    public class ListDomainsItem
    {
        #region Private Variables

        private string _account_id = string.Empty;
        private string _domain = string.Empty;
        private string _home = string.Empty;
        private string _type = string.Empty;
        private string _unique_ip = string.Empty;
        private string _hosting_type = string.Empty;
        private string _user = string.Empty;
        private string _path = string.Empty;
        private string _outside_url = string.Empty;
        private string _www_or_not = string.Empty;
        private string _php = string.Empty;
        private bool _security = false;
        private bool _fastcgi = false;
        private bool _xcache = false;
        private bool _php_fcgid = false;
        private bool _passenger = false;

        #endregion

        #region Accessors

        public string account_id
        {
            get { return this._account_id; }
            set { this._account_id = value; }
        }

        public string domain
        {
            get { return this._domain; }
            set { this._domain = value; }
        }

        public string home
        {
            get { return this._home; }
            set { this._home = value; }
        }

        public string type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public string unique_ip
        {
            get { return this._unique_ip; }
            set { this._unique_ip = value; }
        }

        public string user
        {
            get { return this._user; }
            set { this._user = value; }
        }

        public string path
        {
            get { return this._path; }
            set { this._path = value; }
        }

        public string outside_url
        {
            get { return this._outside_url; }
            set { this._outside_url = value; }
        }

        public string hosting_type
        {
            get { return this._hosting_type; }
            set { this._hosting_type = value; }
        }

        public string www_or_not
        {
            get { return this._www_or_not; }
            set { this._www_or_not = value; }
        }

        public string php
        {
            get { return this._php; }
            set { this._php = value; }
        }

        public bool security
        {
            get { return this._security; }
            set { this._security = value; }
        }

        public bool fastcgi
        {
            get { return this._fastcgi; }
            set { this._fastcgi = value; }
        }

        public bool xcache
        {
            get { return this._xcache; }
            set { this._xcache = value; }
        }

        public bool php_fcgid
        {
            get { return this._php_fcgid; }
            set { this._php_fcgid = value; }
        }

        public bool passenger
        {
            get { return this._passenger; }
            set { this._passenger = value; }
        }

        #endregion

    }
}

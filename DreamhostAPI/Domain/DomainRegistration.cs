using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class DomainRegistration
    {

        private string _account_id;
        private string _domain;
        private DateTime _expires;
        private DateTime _created;
        private DateTime _modified;
        private string _autorenew;
        private bool _locked;
        private bool _expired;
        private string _ns1;
        private string _ns2;
        private string _ns3;
        private string _ns4;
        private string _registrant;
        private string _registrant_org;
        private string _registrant_street1;
        private string _registrant_street2;
        private string _registrant_city;
        private string _registrant_state;
        private string _registrant_zip;
        private string _registrant_country;
        private string _registrant_phone;
        private string _registrant_fax;
        private string _registrant_email;
        private string _tech;
        private string _tech_org;
        private string _tech_street1;
        private string _tech_street2;
        private string _tech_city;
        private string _tech_state;
        private string _tech_zip;
        private string _tech_country;
        private string _tech_phone;
        private string _tech_fax;
        private string _tech_email;
        private string _billing;
        private string _billing_org;
        private string _billing_street1;
        private string _billing_street2;
        private string _billing_city;
        private string _billing_state;
        private string _billing_zip;
        private string _billing_country;
        private string _billing_phone;
        private string _billing_fax;
        private string _billing_email;
        private string _admin;
        private string _admin_org;
        private string _admin_street1;
        private string _admin_street2;
        private string _admin_city;
        private string _admin_state;
        private string _admin_zip;
        private string _admin_country;
        private string _admin_phone;
        private string _admin_fax;
        private string _admin_email;

        public string admin_email
        {
            get { return _admin_email; }
            set { _admin_email = value; }
        }

        public string admin_fax
        {
            get { return _admin_fax; }
            set { _admin_fax = value; }
        }

        public string admin_phone
        {
            get { return _admin_phone; }
            set { _admin_phone = value; }
        }

        public string admin_country
        {
            get { return _admin_country; }
            set { _admin_country = value; }
        }

        public string admin_zip
        {
            get { return _admin_zip; }
            set { _admin_zip = value; }
        }

        public string admin_state
        {
            get { return _admin_state; }
            set { _admin_state = value; }
        }

        public string admin_city
        {
            get { return _admin_city; }
            set { _admin_city = value; }
        }

        public string admin_street2
        {
            get { return _admin_street2; }
            set { _admin_street2 = value; }
        }

        public string admin_street1
        {
            get { return _admin_street1; }
            set { _admin_street1 = value; }
        }

        public string admin_org
        {
            get { return _admin_org; }
            set { _admin_org = value; }
        }

        public string admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public string billing_email
        {
            get { return _billing_email; }
            set { _billing_email = value; }
        }

        public string billing_fax
        {
            get { return _billing_fax; }
            set { _billing_fax = value; }
        }

        public string billing_phone
        {
            get { return _billing_phone; }
            set { _billing_phone = value; }
        }

        public string billing_country
        {
            get { return _billing_country; }
            set { _billing_country = value; }
        }

        public string billing_zip
        {
            get { return _billing_zip; }
            set { _billing_zip = value; }
        }

        public string billing_state
        {
            get { return _billing_state; }
            set { _billing_state = value; }
        }

        public string billing_city
        {
            get { return _billing_city; }
            set { _billing_city = value; }
        }

        public string billing_street2
        {
            get { return _billing_street2; }
            set { _billing_street2 = value; }
        }

        public string billing_street1
        {
            get { return _billing_street1; }
            set { _billing_street1 = value; }
        }


        public string billing_org
        {
            get { return _billing_org; }
            set { _billing_org = value; }
        }

        public string billing
        {
            get { return _billing; }
            set { _billing = value; }
        }

        public string tech_email
        {
            get { return _tech_email; }
            set { _tech_email = value; }
        }

        public string tech_fax
        {
            get { return _tech_fax; }
            set { _tech_fax = value; }
        }

        public string tech_phone
        {
            get { return _tech_phone; }
            set { _tech_phone = value; }
        }

        public string tech_country
        {
            get { return _tech_country; }
            set { _tech_country = value; }
        }

        public string tech_zip
        {
            get { return _tech_zip; }
            set { _tech_zip = value; }
        }

        public string tech_state
        {
            get { return _tech_state; }
            set { _tech_state = value; }
        }

        public string tech_city
        {
            get { return _tech_city; }
            set { _tech_city = value; }
        }

        public string tech_street2
        {
            get { return _tech_street2; }
            set { _tech_street2 = value; }
        }

        public string tech_street1
        {
            get { return _tech_street1; }
            set { _tech_street1 = value; }
        }

        public string tech_org
        {
            get { return _tech_org; }
            set { _tech_org = value; }
        }

        public string tech
        {
            get { return _tech; }
            set { _tech = value; }
        }

        public string registrant_email
        {
            get { return _registrant_email; }
            set { _registrant_email = value; }
        }

        public string registrant_fax
        {
            get { return _registrant_fax; }
            set { _registrant_fax = value; }
        }

        public string registrant_phone
        {
            get { return _registrant_phone; }
            set { _registrant_phone = value; }
        }

        public string registrant_country
        {
            get { return _registrant_country; }
            set { _registrant_country = value; }
        }

        public string registrant_zip
        {
            get { return _registrant_zip; }
            set { _registrant_zip = value; }
        }

        public string registrant_state
        {
            get { return _registrant_state; }
            set { _registrant_state = value; }
        }

        public string registrant_city
        {
            get { return _registrant_city; }
            set { _registrant_city = value; }
        }

        public string registrant_street2
        {
            get { return _registrant_street2; }
            set { _registrant_street2 = value; }
        }

        public string registrant_street1
        {
            get { return _registrant_street1; }
            set { _registrant_street1 = value; }
        }

        public string registrant_org
        {
            get { return _registrant_org; }
            set { _registrant_org = value; }
        }

        public string registrant
        {
            get { return _registrant; }
            set { _registrant = value; }
        }

        public string ns4
        {
            get { return _ns4; }
            set { _ns4 = value; }
        }

        public string ns3
        {
            get { return _ns3; }
            set { _ns3 = value; }
        }

        public string ns2
        {
            get { return _ns2; }
            set { _ns2 = value; }
        }

        public string ns1
        {
            get { return _ns1; }
            set { _ns1 = value; }
        }

        public bool expired
        {
            get { return _expired; }
            set { _expired = value; }
        }

        public bool locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        public string autorenew
        {
            get { return _autorenew; }
            set { _autorenew = value; }
        }

        public DateTime modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public DateTime created
        {
            get { return _created; }
            set { _created = value; }
        }

        public DateTime expires
        {
            get { return _expires; }
            set { _expires = value; }
        }

        public string domain
        {
            get { return _domain; }
            set { _domain = value; }
        }


        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    public class DomainRequests
    {
        #region Constructor

        internal DomainRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        #endregion

        #region Internal Variables

        DreamhostAPI api;

        #endregion

        #region Methods

        public IEnumerable<Domain> ListDomains()
        {
            XDocument response = api.SendCommand("domain-list_domains");

            var domains = from data in response.Element("dreamhost").Elements("data")
                          select new Domain
                          {
                              account_id = data.Element("account_id").AsString(),
                              domain = data.Element("domain").AsString(),
                              fastcgi = data.Element("fastcgi").AsBool(),
                              home = data.Element("home").AsString(),
                              hosting_type = data.Element("hosting_type").AsString(),
                              outside_url = data.Element("outside_url").AsString(),
                              passenger = data.Element("passenger").AsBool(),
                              path = data.Element("path").AsString(),
                              php = data.Element("php").AsString(),
                              php_fcgid = data.Element("php_fcgid").AsBool(),
                              security = data.Element("security").AsBool(),
                              type = data.Element("type").AsString(),
                              unique_ip = data.Element("unique_ip").AsString(),
                              user = data.Element("user").AsString(),
                              www_or_not = data.Element("www_or_not").AsString(),
                              xcache = data.Element("xcache").AsBool()
                          };

            return domains;
        }

        public IEnumerable<DomainRegistration> ListRegistrations()
        {
            XDocument response = api.SendCommand("domain-list_registrations");

            var registrations = from data in response.Element("dreamhost").Elements("data")
                          select new DomainRegistration
                          {
                              account_id = data.Element("account_id").ToString(),
                              domain = data.Element("domain").ToString(),
                              expires = data.Element("expires").AsDateTime(),
                              created = data.Element("created").AsDateTime(),
                              modified = data.Element("modified").AsDateTime(),
                              autorenew = data.Element("autorenew").ToString(),
                              locked = data.Element("locked").AsBool(),
                              expired = data.Element("expired").AsBool(),
                              ns1 = data.Element("ns1").AsString(),
                              ns2 = data.Element("ns2").AsString(),
                              ns3 = data.Element("ns3").AsString(),
                              ns4 = data.Element("ns4").AsString(),
                              registrant = data.Element("registrant").AsString(),
                              registrant_org = data.Element("registrant_org").AsString(),
                              registrant_street1 = data.Element("registrant_street1").AsString(),
                              registrant_street2 = data.Element("registrant_street2").AsString(),
                              registrant_city = data.Element("registrant_city").AsString(),
                              registrant_state = data.Element("registrant_state").AsString(),
                              registrant_zip = data.Element("registrant_zip").AsString(),
                              registrant_country = data.Element("registrant_country").AsString(),
                              registrant_phone = data.Element("registrant_phone").AsString(),
                              registrant_fax = data.Element("registrant_fax").AsString(),
                              registrant_email = data.Element("registrant_email").AsString(),
                              tech = data.Element("tech").AsString(),
                              tech_org = data.Element("tech_org").AsString(),
                              tech_street1 = data.Element("tech_street1").AsString(),
                              tech_street2 = data.Element("tech_street2").AsString(),
                              tech_city = data.Element("tech_city").AsString(),
                              tech_state = data.Element("tech_state").AsString(),
                              tech_zip = data.Element("tech_zip").AsString(),
                              tech_country = data.Element("tech_country").AsString(),
                              tech_phone = data.Element("tech_phone").AsString(),
                              tech_fax = data.Element("tech_fax").AsString(),
                              tech_email = data.Element("tech_email").AsString(),
                              billing = data.Element("billing").AsString(),
                              billing_org = data.Element("billing_org").AsString(),
                              billing_street1 = data.Element("billing_street1").AsString(),
                              billing_street2 = data.Element("billing_street2").AsString(),
                              billing_city = data.Element("billing_city").AsString(),
                              billing_state = data.Element("billing_state").AsString(),
                              billing_zip = data.Element("billing_zip").AsString(),
                              billing_country = data.Element("billing_country").AsString(),
                              billing_phone = data.Element("billing_phone").AsString(),
                              billing_fax = data.Element("billing_fax").AsString(),
                              billing_email = data.Element("billing_email").AsString(),
                              admin = data.Element("admin").AsString(),
                              admin_org = data.Element("admin_org").AsString(),
                              admin_street1 = data.Element("admin_street1").AsString(),
                              admin_street2 = data.Element("admin_street2").AsString(),
                              admin_city = data.Element("admin_city").AsString(),
                              admin_state = data.Element("admin_state").AsString(),
                              admin_zip = data.Element("admin_zip").AsString(),
                              admin_country = data.Element("admin_country").AsString(),
                              admin_phone = data.Element("admin_phone").AsString(),
                              admin_fax = data.Element("admin_fax").AsString(),
                              admin_email = data.Element("admin_email").AsString()
                          };

            return registrations;
        }

        #endregion
    }
}

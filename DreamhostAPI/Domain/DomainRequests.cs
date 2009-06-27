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

            var domains = from data in response.Element("response").Elements("data")
                          select new Domain
                          {
                              account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                              domain = (string)DreamhostAPI.ParseXMLElement(data.Element("domain")),
                              fastcgi = (bool)DreamhostAPI.ParseXMLElement(data.Element("fastcgi"), typeof(bool)),
                              home = (string)DreamhostAPI.ParseXMLElement(data.Element("home")),
                              hosting_type = (string)DreamhostAPI.ParseXMLElement(data.Element("hosting_type")),
                              outside_url = (string)DreamhostAPI.ParseXMLElement(data.Element("outside_url")),
                              passenger = (bool)DreamhostAPI.ParseXMLElement(data.Element("passenger"), typeof(bool)),
                              path = (string)DreamhostAPI.ParseXMLElement(data.Element("path")),
                              php = (string)DreamhostAPI.ParseXMLElement(data.Element("php")),
                              php_fcgid = (bool)DreamhostAPI.ParseXMLElement(data.Element("php_fcgid"), typeof(bool)),
                              security = (bool)DreamhostAPI.ParseXMLElement(data.Element("security"), typeof(bool)),
                              type = (string)DreamhostAPI.ParseXMLElement(data.Element("type")),
                              unique_ip = (string)DreamhostAPI.ParseXMLElement(data.Element("unique_ip")),
                              user = (string)DreamhostAPI.ParseXMLElement(data.Element("user")),
                              www_or_not = (string)DreamhostAPI.ParseXMLElement(data.Element("www_or_not")),
                              xcache = (bool)DreamhostAPI.ParseXMLElement(data.Element("xcache"), typeof(bool))
                          };

            return domains;
        }

        public IEnumerable<DomainRegistration> ListRegistrations()
        {
            XDocument response = api.SendCommand("domain-list_registrations");

            var registrations = from data in response.Element("response").Elements("data")
                          select new DomainRegistration
                          {
                              account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                              domain = (string)DreamhostAPI.ParseXMLElement(data.Element("domain")),
                              expires = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("expires"), typeof(DateTime)),
                              created = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("created"), typeof(DateTime)),
                              modified = (DateTime)DreamhostAPI.ParseXMLElement(data.Element("modified"), typeof(DateTime)),
                              autorenew = (string)DreamhostAPI.ParseXMLElement(data.Element("autorenew")),
                              locked = (bool)DreamhostAPI.ParseXMLElement(data.Element("locked"), typeof(bool)),
                              expired = (bool)DreamhostAPI.ParseXMLElement(data.Element("expired"), typeof(bool)),
                              ns1 = (string)DreamhostAPI.ParseXMLElement(data.Element("ns1")),
                              ns2 = (string)DreamhostAPI.ParseXMLElement(data.Element("ns2")),
                              ns3 = (string)DreamhostAPI.ParseXMLElement(data.Element("ns3")),
                              ns4 = (string)DreamhostAPI.ParseXMLElement(data.Element("ns4")),
                              registrant = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant")),
                              registrant_org = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_org")),
                              registrant_street1 = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_street1")),
                              registrant_street2 = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_street2")),
                              registrant_city = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_city")),
                              registrant_state = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_state")),
                              registrant_zip = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_zip")),
                              registrant_country = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_country")),
                              registrant_phone = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_phone")),
                              registrant_fax = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_fax")),
                              registrant_email = (string)DreamhostAPI.ParseXMLElement(data.Element("registrant_email")),
                              tech = (string)DreamhostAPI.ParseXMLElement(data.Element("tech")),
                              tech_org = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_org")),
                              tech_street1 = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_street1")),
                              tech_street2 = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_street2")),
                              tech_city = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_city")),
                              tech_state = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_state")),
                              tech_zip = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_zip")),
                              tech_country = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_country")),
                              tech_phone = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_phone")),
                              tech_fax = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_fax")),
                              tech_email = (string)DreamhostAPI.ParseXMLElement(data.Element("tech_email")),
                              billing = (string)DreamhostAPI.ParseXMLElement(data.Element("billing")),
                              billing_org = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_org")),
                              billing_street1 = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_street1")),
                              billing_street2 = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_street2")),
                              billing_city = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_city")),
                              billing_state = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_state")),
                              billing_zip = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_zip")),
                              billing_country = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_country")),
                              billing_phone = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_phone")),
                              billing_fax = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_fax")),
                              billing_email = (string)DreamhostAPI.ParseXMLElement(data.Element("billing_email")),
                              admin = (string)DreamhostAPI.ParseXMLElement(data.Element("admin")),
                              admin_org = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_org")),
                              admin_street1 = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_street1")),
                              admin_street2 = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_street2")),
                              admin_city = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_city")),
                              admin_state = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_state")),
                              admin_zip = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_zip")),
                              admin_country = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_country")),
                              admin_phone = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_phone")),
                              admin_fax = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_fax")),
                              admin_email = (string)DreamhostAPI.ParseXMLElement(data.Element("admin_email"))
                          };

            return registrations;
        }

        #endregion
    }
}

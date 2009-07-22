using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    public class MySQLRequests
    {
        DreamhostAPI api;

        internal MySQLRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        public IEnumerable<DB> ListDBs()
        {
            XDocument response = api.SendCommand("mysql-list_dbs");
            
            var dbs = from data in response.Element("response").Elements("data")
                      select new DB
                      {
                          account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                          db = (string)DreamhostAPI.ParseXMLElement(data.Element("db")),
                          description = (string)DreamhostAPI.ParseXMLElement(data.Element("description")),
                          home = (string)DreamhostAPI.ParseXMLElement(data.Element("home")),
                          disk_usage_mb = (double)DreamhostAPI.ParseXMLElement(data.Element("disk_usage_mb"), typeof(double))
                      };

            return dbs;
        }

        public IEnumerable<DBHostname> ListHostnames()
        {
            XDocument response = api.SendCommand("mysql-list_hostnames");

            var hostnames = from data in response.Element("response").Elements("data")
                            select new DBHostname
                            {
                                account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                                domain = (string)DreamhostAPI.ParseXMLElement(data.Element("domain")),
                                home = (string)DreamhostAPI.ParseXMLElement(data.Element("home"))
                            };

            return hostnames;
        }

        public void AddHostname(string hostname)
        {
            QueryData[] parameters = { new QueryData("hostname", hostname) };

            api.SendCommand("mysql-add_hostname", parameters);
        }

        public void RemoveHostname(string hostname)
        {
            QueryData[] parameters = { new QueryData("hostname", hostname) };

            api.SendCommand("mysql-remove_hostname", parameters);
        }

        public IEnumerable<DBUser> ListUsers()
        {
            XDocument response = api.SendCommand("mysql-list_users");

            var users = from data in response.Element("response").Elements("data")
                        select new DBUser
                        {
                            account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                            db = (string)DreamhostAPI.ParseXMLElement(data.Element("db")),
                            home = (string)DreamhostAPI.ParseXMLElement(data.Element("home")),
                            username = (string)DreamhostAPI.ParseXMLElement(data.Element("username")),
                            host = (string)DreamhostAPI.ParseXMLElement(data.Element("host")),
                            select_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("select_priv"), typeof(bool)),
                            insert_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("insert_priv"), typeof(bool)),
                            update_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("update_priv"), typeof(bool)),
                            delete_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("delete_priv"), typeof(bool)),
                            create_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("create_priv"), typeof(bool)),
                            drop_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("drop_priv"), typeof(bool)),
                            index_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("index_priv"), typeof(bool)),
                            alter_priv = (bool)DreamhostAPI.ParseXMLElement(data.Element("alter_priv"), typeof(bool))
                        };

            return users;
        }

        public void AddUser(string db, string user, string password, string select, string insert, string update, string delete, string create, string drop, string index, string alter, string hostnames)
        {
            QueryData[] parameters = {
                                         new QueryData("db", db),
                                         new QueryData("user", user),
                                         new QueryData("password", password),
                                         new QueryData("select", select),
                                         new QueryData("insert", insert),
                                         new QueryData("update", update),
                                         new QueryData("delete", delete),
                                         new QueryData("create", create),
                                         new QueryData("drop", drop),
                                         new QueryData("index", index),
                                         new QueryData("hostnames", hostnames)
                                     };

            api.SendCommand("mysql-add_user", parameters);
        }

        public void RemoveUser(string db, string user, string select, string insert, string update, string delete, string create, string drop, string index, string alter)
        {
            QueryData[] parameters = {
                                         new QueryData("db", db),
                                         new QueryData("user", user),
                                         new QueryData("select", select),
                                         new QueryData("insert", insert),
                                         new QueryData("update", update),
                                         new QueryData("delete", delete),
                                         new QueryData("create", create),
                                         new QueryData("drop", drop),
                                         new QueryData("index", index)
                                     };

            api.SendCommand("mysql-remove_user", parameters);
        }



    }
}

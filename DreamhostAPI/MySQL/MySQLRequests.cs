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
            
            var dbs = from data in response.Element("dreamhost").Elements("data")
                      select new DB
                      {
                          account_id = data.Element("account_id").AsString(),
                          db = data.Element("db").AsString(),
                          description = data.Element("description").AsString(),
                          home = data.Element("home").AsString(),
                          disk_usage_mb = data.Element("disk_usage_mb").AsDouble()
                      };

            return dbs;
        }

        public IEnumerable<DBHostname> ListHostnames()
        {
            XDocument response = api.SendCommand("mysql-list_hostnames");

            var hostnames = from data in response.Element("dreamhost").Elements("data")
                            select new DBHostname
                            {
                                account_id = data.Element("account_id").AsString(),
                                domain = data.Element("domain").AsString(),
                                home = data.Element("home").AsString()
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

            var users = from data in response.Element("dreamhost").Elements("data")
                        select new DBUser
                        {
                            account_id = data.Element("account_id").AsString(),
                            db = data.Element("db").AsString(),
                            home = data.Element("home").AsString(),
                            username = data.Element("username").AsString(),
                            host = data.Element("host").AsString(),
                            select_priv = data.Element("select_priv").AsBool(),
                            insert_priv = data.Element("insert_priv").AsBool(),
                            update_priv = data.Element("update_priv").AsBool(),
                            delete_priv = data.Element("delete_priv").AsBool(),
                            create_priv = data.Element("create_priv").AsBool(),
                            drop_priv = data.Element("drop_priv").AsBool(),
                            index_priv = data.Element("index_priv").AsBool(),
                            alter_priv = data.Element("alter_priv").AsBool()
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

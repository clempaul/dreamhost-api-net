using System;
using System.Collections.Generic;
using System.Linq;
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

        #region mysql-list_dbs

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

        #endregion

        #region mysql-list_hostnames

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

        #endregion

        #region mysql-add_hostname

        public void AddHostname(string hostname)
        {
            QueryData[] parameters = { new QueryData("hostname", hostname) };

            api.SendCommand("mysql-add_hostname", parameters);
        }

        /*
         * Overloads
         */

        public void AddHostname(DBHostname hostname)
        {
            this.AddHostname(hostname.domain);
        }

        #endregion

        #region mysql-remove_hostname

        public void RemoveHostname(string hostname)
        {
            QueryData[] parameters = { new QueryData("hostname", hostname) };

            api.SendCommand("mysql-remove_hostname", parameters);
        }

        /*
         * Overloads
         */

        public void RemoveHostname(DBHostname hostname)
        {
            this.RemoveHostname(hostname.domain);
        }

        #endregion

        #region mysql-list_users

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

        #endregion

        #region mysql-add_user

        public void AddUser(DBUser user)
        {
            // Check parameters

            if (user.db == null || user.db == string.Empty)
            {
                throw new Exception("Missing db parameter");
            }
            else if (user.username == null || user.username == string.Empty)
            {
                throw new Exception("Missing user parameter");
            }
            else if (user.password == null || user.password == string.Empty)
            {
                throw new Exception("Missing password parameter");
            }

            // Construct request

            List<QueryData> parameters = new List<QueryData>();

            parameters.Add(new QueryData("db", user.db));
            parameters.Add(new QueryData("user", user.username));
            parameters.Add(new QueryData("password", user.password));

            if (user.select_priv != null)
            {
                parameters.Add(new QueryData("select", user.select_priv.AsYN()));
            }

            if (user.insert_priv != null)
            {
                parameters.Add(new QueryData("insert", user.insert_priv.AsYN()));
            }

            if (user.update_priv != null)
            {
                parameters.Add(new QueryData("update", user.update_priv.AsYN()));
            }

            if (user.delete_priv != null)
            {
                parameters.Add(new QueryData("delete", user.delete_priv.AsYN()));
            }

            if (user.create_priv != null)
            {
                parameters.Add(new QueryData("create", user.create_priv.AsYN()));
            }

            if (user.drop_priv != null)
            {
                parameters.Add(new QueryData("drop", user.drop_priv.AsYN()));
            }

            if (user.index_priv != null)
            {
                parameters.Add(new QueryData("index", user.index_priv.AsYN()));
            }

            if (user.alter_priv != null)
            {
                parameters.Add(new QueryData("alter", user.alter_priv.AsYN()));
            }

            if (user.host != null)
            {
                parameters.Add(new QueryData("hostnames", user.host));
            }

            api.SendCommand("mysql-add_user", parameters);
        }

        #endregion

        #region mysql-remove_user

        public void RemoveUser(DBUser user)
        {
            // Check parameters

            if (user.db == null || user.db == string.Empty)
            {
                throw new Exception("Missing db parameter");
            }

            else if (user.username == null || user.username == string.Empty)
            {
                throw new Exception("Missing user parameter");
            }

            else if (user.select_priv == null)
            {
                throw new Exception("Missing select parameter");
            }

            else if (user.insert_priv == null)
            {
                throw new Exception("Missing insert parameter");
            }

            else if (user.update_priv == null)
            {
                throw new Exception("Missing update parameter");
            }

            else if (user.delete_priv == null)
            {
                throw new Exception("Missing delete parameter");
            }

            else if (user.create_priv == null)
            {
                throw new Exception("Missing create parameter");
            }

            else if (user.drop_priv == null)
            {
                throw new Exception("Missing drop parameter");
            }

            else if (user.index_priv == null)
            {
                throw new Exception("Missing index parameter");
            }

            else if (user.alter_priv == null)
            {
                throw new Exception("Missing alter parameter");
            }

            // Create request

            QueryData[] parameters = {
                                         new QueryData("db", user.db),
                                         new QueryData("user", user.username),
                                         new QueryData("select", user.select_priv.AsYN()),
                                         new QueryData("insert", user.insert_priv.AsYN()),
                                         new QueryData("update", user.update_priv.AsYN()),
                                         new QueryData("delete", user.delete_priv.AsYN()),
                                         new QueryData("create", user.create_priv.AsYN()),
                                         new QueryData("drop", user.drop_priv.AsYN()),
                                         new QueryData("index", user.index_priv.AsYN()),
                                         new QueryData("alter", user.alter_priv.AsYN())
                                     };

            api.SendCommand("mysql-remove_user", parameters);
        }

        #endregion

    }
}

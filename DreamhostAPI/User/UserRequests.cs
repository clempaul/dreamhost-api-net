using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    public class UserRequests
    {
        private DreamhostAPI api;

        internal UserRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        #region user-list_users

        public IEnumerable<User> ListUsers()
        {
            XDocument response = api.SendCommand("user-list_users");

            var users = from data in response.Element("dreamhost").Elements("data")
                        select new User
                        {
                            account_id = data.Element("account_id").AsString(),
                            username = data.Element("username").AsString(),
                            type = data.Element("type").AsString(),
                            shell = data.Element("shell").AsString(),
                            home = data.Element("home").AsString(),
                            password = data.Element("password").AsString(),
                            disk_user_mb = data.Element("disk_used_mb").AsDouble(),
                            quota_mb = data.Element("quota_mb").AsDouble(),
                            gecos = data.Element("gecos").AsString(),
                        };

            return users;
        }

        #endregion

        #region user-list_user_no_pw

        public IEnumerable<User> ListUsersNoPw()
        {
            XDocument response = api.SendCommand("user-list_users_no_pw");

            var users = from data in response.Element("dreamhost").Elements("data")
                        select new User
                        {
                            account_id = data.Element("account_id").AsString(),
                            username = data.Element("username").AsString(),
                            type = data.Element("type").AsString(),
                            shell = data.Element("shell").AsString(),
                            home = data.Element("home").AsString(),
                            disk_user_mb = data.Element("disk_used_mb").AsDouble(),
                            quota_mb = data.Element("quota_mb").AsDouble(),
                            gecos = data.Element("gecos").AsString(),
                        };

            return users;
        }

        #endregion
    }
}

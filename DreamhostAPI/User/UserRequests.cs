﻿using System;
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

        public IEnumerable<User> ListUsers()
        {
            XDocument response = api.SendCommand("user-list_users");

            var users = from data in response.Element("response").Elements("data")
                        select new User
                        {
                            account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                            username = (string)DreamhostAPI.ParseXMLElement(data.Element("username")),
                            type = (string)DreamhostAPI.ParseXMLElement(data.Element("type")),
                            shell = (string)DreamhostAPI.ParseXMLElement(data.Element("shell")),
                            home = (string)DreamhostAPI.ParseXMLElement(data.Element("home")),
                            password = (string)DreamhostAPI.ParseXMLElement(data.Element("password")),
                            disk_user_mb = (double)DreamhostAPI.ParseXMLElement(data.Element("disk_used_mb"), typeof(double)),
                            quota_mb = (double)DreamhostAPI.ParseXMLElement(data.Element("quota_mb"), typeof(double)),
                            gecos = (string)DreamhostAPI.ParseXMLElement(data.Element("gecos")),
                        };

            return users;
        }

        public IEnumerable<User> ListUsersNoPw()
        {
            XDocument response = api.SendCommand("user-list_users_no_pw");

            var users = from data in response.Element("response").Elements("data")
                        select new User
                        {
                            account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                            username = (string)DreamhostAPI.ParseXMLElement(data.Element("username")),
                            type = (string)DreamhostAPI.ParseXMLElement(data.Element("type")),
                            shell = (string)DreamhostAPI.ParseXMLElement(data.Element("shell")),
                            home = (string)DreamhostAPI.ParseXMLElement(data.Element("home")),
                            disk_user_mb = (double)DreamhostAPI.ParseXMLElement(data.Element("disk_used_mb"), typeof(double)),
                            quota_mb = (double)DreamhostAPI.ParseXMLElement(data.Element("quota_mb"), typeof(double)),
                            gecos = (string)DreamhostAPI.ParseXMLElement(data.Element("gecos")),
                        };

            return users;
        }
    }
}
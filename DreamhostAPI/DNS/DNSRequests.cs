using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using clempaul.Dreamhost.ResponseData;

namespace clempaul.Dreamhost
{
    public class DNSRequests
    {

        #region Internal Variables

        DreamhostAPI api;

        #endregion

        #region Constructor

        internal DNSRequests(DreamhostAPI api)
        {
            this.api = api;
        }

        #endregion

        #region dns-list_records

        public IEnumerable<DNSRecord> ListRecords()
        {
            XDocument response = api.SendCommand("dns-list_records");

            var records = from data in response.Element("dreamhost").Elements("data")
                          select new DNSRecord
                          {
                              account_id = data.Element("account_id").AsString(),
                              comment = data.Element("comment").AsString(),
                              editable = data.Element("editable").AsBool(),
                              type = data.Element("type").AsString(),
                              value = data.Element("value").AsString(),
                              record = data.Element("record").AsString(),
                              zone = data.Element("zone").AsString()
                          };

            return records;
        }

        #endregion

        #region dns-add_record

        public void AddRecord(string record, string type, string value, string comment)
        {
            // Check parameters 

            if (record == null || record == string.Empty)
            {
                throw new Exception("Missing record parameter");
            }
            else if (type == null || type == string.Empty)
            {
                throw new Exception("Missing type parameter");
            }
            else if (value == null || value == string.Empty)
            {
                throw new Exception("Missing value parameter");
            }

            // Build request

            List<QueryData> parameters = new List<QueryData>();

            parameters.Add(new QueryData("record", record));
            parameters.Add(new QueryData("type", type));
            parameters.Add(new QueryData("value", value));

            if (comment != string.Empty && comment != null)
            {
                parameters.Add(new QueryData("comment", comment));
            }

            api.SendCommand("dns-add_record", parameters);
        }

        /*
         * Overloads
         */

        public void AddRecord(string record, string type, string value)
        {
            this.AddRecord(record, type, value, string.Empty);
        }

        public void AddRecord(DNSRecord record)
        {
            this.AddRecord(record.record, record.type, record.value, record.comment);
        }

        #endregion

        #region dns-remove_record

        public void RemoveRecord(string record, string type, string value)
        {
            // Check parameters

            if (record == null || record == string.Empty)
            {
                throw new Exception("Missing record parameter");
            }
            else if (type == null || type == string.Empty)
            {
                throw new Exception("Missing type parameter");
            }
            else if (value == null || value == string.Empty)
            {
                throw new Exception("Missing value parameter");
            }
        
            // Build request

            QueryData[] parameters = {
                                         new QueryData("record", record),
                                         new QueryData("type", type),
                                         new QueryData("value", value)
                                     };

            api.SendCommand("dns-remove_record", parameters);
        }

        /*
         * Overloads
         */

        public void RemoveRecord(DNSRecord record)
        {
            this.RemoveRecord(record.record, record.type, record.value);
        }

        #endregion

    }
}

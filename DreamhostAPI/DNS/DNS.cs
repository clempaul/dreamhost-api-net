using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace clempaul.Dreamhost
{
    public class DNS
    {

        #region Internal Variables

        DreamhostAPI api;

        #endregion

        #region Constructor

        internal DNS(DreamhostAPI api)
        {
            this.api = api;
        }

        #endregion

        #region Methods

        public IEnumerable<DNSRecord> ListRecords()
        {
            XDocument response = api.SendCommand("dns-list_records");

            var records = from data in response.Element("response").Elements("data")
                          select new DNSRecord
                          {
                              account_id = (string)DreamhostAPI.ParseXMLElement(data.Element("account_id")),
                              comment = (string)DreamhostAPI.ParseXMLElement(data.Element("comment")),
                              editable = (bool)DreamhostAPI.ParseXMLElement(data.Element("editable"), typeof(bool)),
                              type = (string)DreamhostAPI.ParseXMLElement(data.Element("type")),
                              value = (string)DreamhostAPI.ParseXMLElement(data.Element("value")),
                              record = (string)DreamhostAPI.ParseXMLElement(data.Element("record")),
                              zone = (string)DreamhostAPI.ParseXMLElement(data.Element("zone"))
                          };

            return records;
        }

        public void AddRecord(string record, string type, string value)
        {
            AddRecord(record, type, value, string.Empty);
        }

        public void AddRecord(string record, string type, string value, string comment)
        {
            QueryData[] parameters = new QueryData[4];

            parameters[0] = new QueryData("record", record);
            parameters[1] = new QueryData("type", type);
            parameters[2] = new QueryData("value", value);

            if (comment != string.Empty && comment != null)
            {
                parameters[3] = new QueryData("comment", comment);
            }

            api.SendCommand("dns-add_record", parameters);
        }

        public void RemoveRecord(string record, string type, string value)
        {
            QueryData[] parameters = {
                                         new QueryData("record", record),
                                         new QueryData("type", type),
                                         new QueryData("value", value)
                                     };

            api.SendCommand("dns-remove_record", parameters);
        }

        #endregion
    }
}

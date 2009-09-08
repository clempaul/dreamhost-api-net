using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class DNSRecord
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }
        private string _zone;

        public string zone
        {
            get { return _zone; }
            set { _zone = value; }
        }
        private string _type = string.Empty;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _value = string.Empty;

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _comment = string.Empty;

        public string comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        private bool _editable;

        public bool editable
        {
            get { return _editable; }
            set { _editable = value; }
        }

        private string _record = string.Empty;

        public string record
        {
            get { return _record; }
            set { _record = value; }
        }



    }
}

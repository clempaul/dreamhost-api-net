using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class Announcement
    {
        private string _subject = string.Empty;

        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private string _message = string.Empty;

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        private DateTime? _stamp = null;

        public DateTime? stamp
        {
            get { return _stamp; }
            set { _stamp = value; }
        }

        private string _charset = string.Empty;

        public string charset
        {
            get { return _charset; }
            set { _charset = value; }
        }

        private string _type = string.Empty;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private bool? _duplicate_ok = null;

        public bool? duplicate_ok
        {
            get { return _duplicate_ok; }
            set { _duplicate_ok = value; }
        }
    }
}

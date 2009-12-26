using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    public class DestroyResult
    {
        private string _database;

        public string database
        {
            get { return _database; }
            set { _database = value; }
        }

        private string _prefix;

        public string prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

    }
}

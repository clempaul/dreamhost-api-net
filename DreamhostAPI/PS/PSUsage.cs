using System;

namespace clempaul.Dreamhost.ResponseData
{
    class PSUsage
    {
        private DateTime _stamp;

        public DateTime stamp
        {
            get { return _stamp; }
            set { _stamp = value; }
        }

        private int _memory_mb;

        public int memory_mb
        {
            get { return _memory_mb; }
            set { _memory_mb = value; }
        }

        private double _load;

        public double load
        {
            get { return _load; }
            set { _load = value; }
        }
    }
}

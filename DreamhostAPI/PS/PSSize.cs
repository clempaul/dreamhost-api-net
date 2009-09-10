using System;

namespace clempaul.Dreamhost.ResponseData
{
    class PSSize
    {
        private DateTime _stamp;

        public DateTime stamp
        {
            get { return _stamp; }
            set { _stamp = value; }
        }

        private int _period_seconds;

        public int period_seconds
        {
            get { return _period_seconds; }
            set { _period_seconds = value; }
        }

        private int _memory_mb;

        public int memory_mb
        {
            get { return _memory_mb; }
            set { _memory_mb = value; }
        }

        private double _monthly_cost;

        public double monthly_cost
        {
            get { return _monthly_cost; }
            set { _monthly_cost = value; }
        }

        private double _period_cost;

        public double period_cost
        {
            get { return _period_cost; }
            set { _period_cost = value; }
        }
    }
}

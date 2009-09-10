namespace clempaul.Dreamhost.ResponseData
{
    public class User
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _username;

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _type;

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _shell;

        public string shell
        {
            get { return _shell; }
            set { _shell = value; }
        }

        private string _home;

        public string home
        {
            get { return _home; }
            set { _home = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private double _disk_user_mb;

        public double disk_user_mb
        {
            get { return _disk_user_mb; }
            set { _disk_user_mb = value; }
        }

        private double _quota_mb;

        public double quota_mb
        {
            get { return _quota_mb; }
            set { _quota_mb = value; }
        }

        private string _gecos;

        public string gecos
        {
            get { return _gecos; }
            set { _gecos = value; }
        }
    }
}

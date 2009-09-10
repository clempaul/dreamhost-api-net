namespace clempaul.Dreamhost.ResponseData
{
    public class DBUser
    {
        private string _account_id;

        public string account_id
        {
            get { return _account_id; }
            set { _account_id = value; }
        }

        private string _db;

        public string db
        {
            get { return _db; }
            set { _db = value; }
        }

        private string _home;

        public string home
        {
            get { return _home; }
            set { _home = value; }
        }

        private string _username = string.Empty;

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password = string.Empty;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _host = string.Empty;

        public string host
        {
            get { return _host; }
            set { _host = value; }
        }

        private bool? _select_priv;

        public bool? select_priv
        {
            get { return _select_priv; }
            set { _select_priv = value; }
        }

        private bool? _insert_priv;

        public bool? insert_priv
        {
            get { return _insert_priv; }
            set { _insert_priv = value; }
        }

        private bool? _update_priv;

        public bool? update_priv
        {
            get { return _update_priv; }
            set { _update_priv = value; }
        }

        private bool? _delete_priv;

        public bool? delete_priv
        {
            get { return _delete_priv; }
            set { _delete_priv = value; }
        }

        private bool? _create_priv;

        public bool? create_priv
        {
            get { return _create_priv; }
            set { _create_priv = value; }
        }

        private bool? _drop_priv;

        public bool? drop_priv
        {
            get { return _drop_priv; }
            set { _drop_priv = value; }
        }

        private bool? _index_priv;

        public bool? index_priv
        {
            get { return _index_priv; }
            set { _index_priv = value; }
        }

        private bool? _alter_priv;

        public bool? alter_priv
        {
            get { return _alter_priv; }
            set { _alter_priv = value; }
        }
    }
}

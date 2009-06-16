using System;

namespace clempaul.Dreamhost
{
    internal class QueryData
    {

        #region Constructor

        internal QueryData(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        #endregion

        #region Internal Variables

        private string key = String.Empty;
        private string value = String.Empty;

        #endregion

        #region Accessors

        internal string Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        internal string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion

    }
}

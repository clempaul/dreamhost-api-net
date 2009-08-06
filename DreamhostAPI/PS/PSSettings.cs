using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clempaul.Dreamhost.ResponseData
{
    class PSSettings
    {

        Dictionary<string, string> values = new Dictionary<string, string>();
        
        public void set(string name, string value)
        {
            this.values.Add(name, value);
            
        }

        public string get(string name)
        {
            return this.values[name];
        }

        public Dictionary<string, string> getValues()
        {
            return this.values;
        }
    }
}

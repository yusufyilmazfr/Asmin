using System;
using System.Collections.Generic;
using System.Text;

namespace Asmin.Packages.JWT.Entities
{
    public class ClaimKeyValuePair
    {
        public ClaimKeyValuePair()
        {

        }

        public ClaimKeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Claim key.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Claim value.
        /// </summary>
        public string Value { get; set; }
    }
}

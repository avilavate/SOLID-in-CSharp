using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArdalisRating
{
    class PolicyIO
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}

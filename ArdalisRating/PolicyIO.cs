using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        public Policy DeserializePolicy(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}

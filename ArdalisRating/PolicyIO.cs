using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AvilRating
{
    class PolicyIO
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }

        public Policy DeserializePolicy(string policyJson)
        {
            try
            {
                return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
            }
            catch (Exception)
            {

                return null;
            }
            
        }
    }
}

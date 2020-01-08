using ArdalisRating.Factory;
using ArdalisRating.Raters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        private Logger _Logger { get; } = new Logger();
        private PolicyIO _PolicyIO { get; } = new PolicyIO();
        public void Rate()
        {
            _Logger.Log("Starting rate.");

            _Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _PolicyIO.GetPolicyFromSource();
            Policy policy = _PolicyIO.DeserializePolicy(policyJson);

            var rater = new RaterFactory().Create(this, policy);
            rater.Rate();

            _Logger.Log("Rating completed.");
        }



    }
}

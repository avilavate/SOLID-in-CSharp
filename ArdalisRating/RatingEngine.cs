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

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    _Logger.Log("Rating AUTO policy...");
                    _Logger.Log("Validating policy.");
                    if (String.IsNullOrEmpty(policy.Make))
                    {
                        _Logger.Log("Auto policy must specify Make");
                        return;
                    }
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    _Logger.Log("Rating LAND policy...");
                    _Logger.Log("Validating policy.");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        _Logger.Log("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        _Logger.Log("Insufficient bond amount.");
                        return;
                    }
                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:
                    _Logger.Log("Rating LIFE policy...");
                    _Logger.Log("Validating policy.");
                    if (policy.DateOfBirth == DateTime.MinValue)
                    {
                        _Logger.Log("Life policy must include Date of Birth.");
                        return;
                    }
                    if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                    {
                        _Logger.Log("Centenarians are not eligible for coverage.");
                        return;
                    }
                    if (policy.Amount == 0)
                    {
                        _Logger.Log("Life policy must include an Amount.");
                        return;
                    }
                    int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                    if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                        DateTime.Today.Day < policy.DateOfBirth.Day ||
                        DateTime.Today.Month < policy.DateOfBirth.Month)
                    {
                        age--;
                    }
                    decimal baseRate = policy.Amount * age / 200;
                    if (policy.IsSmoker)
                    {
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    _Logger.Log("Unknown policy type");
                    break;
            }

            _Logger.Log("Rating completed.");
        }

      
    }
}

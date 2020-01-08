using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Raters
{
    class LifeRater
    {
        private readonly Logger _Logger = new Logger();
        public RatingEngine engine { get; set; }
        public Policy policy { get; set; }

        public LifeRater(RatingEngine engine, Policy policy)
        {
            this.engine = engine;
            this.policy = policy;
        }
        public void Rate()
        {
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
                engine.Rating = baseRate * 2;
            }
            engine.Rating = baseRate;
        }
    }
}

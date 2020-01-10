using System;
using System.Collections.Generic;
using System.Text;

namespace AvilRating.Raters
{
    class LandRater: IRater
    {
        private readonly Logger _Logger = new Logger();
        public RatingEngine engine { get; set; }
        public Policy policy { get; set; }

        public LandRater(RatingEngine engine, Policy policy)
        {
            this.engine = engine;
            this.policy = policy;
        }

        public void Rate()
        {
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
            engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}

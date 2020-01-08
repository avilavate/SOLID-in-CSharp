using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Raters
{
    class AutoRater: IRater
    {
        private readonly Logger _Logger = new Logger();
        public RatingEngine engine { get; set; }
        public Policy policy { get; set; }

        public AutoRater(RatingEngine engine, Policy policy )
        {
            this.engine = engine;
            this.policy = policy;
        }

        public void Rate()
        {
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
                    engine.Rating = 1000m;
                }
                engine.Rating = 900m;
            }
        }
    }
}

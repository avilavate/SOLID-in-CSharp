using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Raters
{
    class NullRater : IRater
    {
        public NullRater(RatingEngine engine, Policy policy)
        {
            this.engine = engine;
            this.policy = policy;
        }

        public RatingEngine engine { get; set; } = null;
        public Policy policy { get; set; } = null;

        public void Rate()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Raters
{
    class NullRater : IRater
    {
        public RatingEngine engine { get; set; } = null;
        public Policy policy { get; set; } = null;

        public void Rate()
        {

        }
    }
}

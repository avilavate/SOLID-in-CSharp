using System;
using System.Collections.Generic;
using System.Text;

namespace AvilRating.Raters
{
    class NullRater : IRater
    {
        public RatingEngine engine { get; set; } = null;
        public Policy policy { get; set; } = null;
        public Logger _Logger { get; set; } = new Logger();
        public void Rate()
        {
           _Logger.Log("No Policy Found!");
        }
    }
}

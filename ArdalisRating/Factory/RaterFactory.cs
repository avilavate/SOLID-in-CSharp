using AvilRating.Raters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvilRating.Factory
{
    class RaterFactory
    {
        public IRater Create(RatingEngine engine, Policy policy)
        {
            try
            {
                return (IRater)
               Activator.CreateInstance(
                   Type.GetType($"AvilRating.Raters." + policy.Type.ToString() + "Rater")
                   , new Object[] {
                        engine, policy
                   });
            }
            catch (Exception)
            {
                //Null Object patter
                return new NullRater();
            }

            //switch (policy.Type)
            //{
            //    case PolicyType.Life:
            //        return new LifeRater(engine, policy);

            //    case PolicyType.Land:
            //        return new LandRater(engine, policy);

            //    case PolicyType.Auto:
            //        return new AutoRater(engine, policy);
            //    default:
            //        return new NullRater(engine, policy);
            //        //Null Object design pattern
            //}
        }
    }
}

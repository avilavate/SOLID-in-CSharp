namespace ArdalisRating.Raters
{
    interface IRater
    {
        RatingEngine engine { get; set; }
        Policy policy { get; set; }

        void Rate();
    }
}
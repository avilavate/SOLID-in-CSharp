namespace AvilRating.Raters
{
    interface IRater
    {
        RatingEngine engine { get; set; }
        Policy policy { get; set; }

        void Rate();
    }
}
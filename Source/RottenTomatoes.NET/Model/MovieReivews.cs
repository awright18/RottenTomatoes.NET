using System.Collections.Generic;

namespace RottenTomatoes.Model
{
    public sealed class MovieReviews
    {
        public int? Total { get; set; }
        public List<MovieReview> Reviews { get; set; }
    }
}

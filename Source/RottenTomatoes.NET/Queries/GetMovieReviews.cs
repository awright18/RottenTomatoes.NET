using RottenTomatoes.Model;

namespace RottenTomatoes.Queries
{
    internal sealed class GetMovieReviewsQuery:RottenTomatoesQuery<MovieReviews>
    {
        public GetMovieReviewsQuery(string movieid, 
            string reviewType = Parameters.DefaultMovieReviewType,
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            Url = Endpoints.Movies.GetMovieReviewsUrl(movieid);

            AddStringParameter(Parameters.MovieReviewType, reviewType);
            AddIntParameter(Parameters.PageNumber, pageNumber);
            AddIntParameter(Parameters.PageLimit, pageLimit);
            AddStringParameter(Parameters.Country, country);
        }
    }
}


namespace RottenTomatoes.Queries
{
    internal sealed class GetOpeningMoviesQuery:RottenTomatoesMoviesQuery
    {
        internal GetOpeningMoviesQuery(
            int limit = Parameters.DefaultLimit,
            string country = Parameters.DefaultCountry)
            : base(limit, country)
        {
            Url = Endpoints.Lists.Movies.OpeningUrl;
        }
    }
}

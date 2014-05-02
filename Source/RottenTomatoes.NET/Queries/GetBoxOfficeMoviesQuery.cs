namespace RottenTomatoes.Queries
{
    internal sealed class GetBoxOfficeMoviesQuery:RottenTomatoesMoviesQuery
    {
        internal GetBoxOfficeMoviesQuery(
            int limit = Parameters.DefaultLimit,
            string country = Parameters.DefaultCountry)
            : base(limit, country)
        {
            Url = Endpoints.Lists.Movies.BoxOfficeUrl;
        }
    }
}

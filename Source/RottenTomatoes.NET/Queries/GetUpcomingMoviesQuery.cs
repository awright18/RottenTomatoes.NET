namespace RottenTomatoes.Queries
{
    internal sealed class GetUpcomingMoviesQuery : RottenTomatoesMoviesQuery
    {
        internal GetUpcomingMoviesQuery(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
            : base(pageNumber,pageLimit, country)
        {
            Url = Endpoints.Lists.Movies.UpcomingUrl;
        }
    }
}

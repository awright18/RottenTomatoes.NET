namespace RottenTomatoes.Queries
{
    internal sealed class GetMoviesInTheatersQuery : RottenTomatoesMoviesQuery
    {
        internal GetMoviesInTheatersQuery(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
                : base(pageNumber, pageLimit, country)
        {
            Url = Endpoints.Lists.Movies.InTheatresUrl;
        }
    }
}

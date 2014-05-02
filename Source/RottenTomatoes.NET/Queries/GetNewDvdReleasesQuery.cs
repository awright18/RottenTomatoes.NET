namespace RottenTomatoes.Queries
{
    internal sealed class GetNewDvdReleasesQuery: RottenTomatoesMoviesQuery
    {
        internal GetNewDvdReleasesQuery(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
            : base(pageNumber, pageLimit, country)
        {
            Url = Endpoints.Lists.Dvds.NewReleasesUrl;
        }
    }
}

namespace RottenTomatoes.Queries
{
    internal sealed class GetCurrentDvdReleasesQuery: RottenTomatoesMoviesQuery
    {
        internal GetCurrentDvdReleasesQuery(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit, 
            string country = Parameters.DefaultCountry)
            : base(pageNumber, pageLimit, country)
        {
            Url = Endpoints.Lists.Dvds.CurrentReleasesUrl;
        }
    }
}

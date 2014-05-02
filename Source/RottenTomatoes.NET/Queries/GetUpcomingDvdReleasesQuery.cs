namespace RottenTomatoes.Queries
{
    internal sealed class GetUpcomingDvdReleasesQuery:RottenTomatoesMoviesQuery
    {
        internal GetUpcomingDvdReleasesQuery(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultLimit, 
            string country = Parameters.DefaultCountry)
            :base(pageNumber,pageLimit,country)
        {
            Url = Endpoints.Lists.Dvds.UpcomingUrl;
        }
    }
}

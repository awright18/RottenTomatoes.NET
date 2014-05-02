namespace RottenTomatoes.Queries
{
    internal sealed class GetTopRentalMoviesQuery : RottenTomatoesMoviesQuery
    {
        internal GetTopRentalMoviesQuery(
            int limit = Parameters.DefaultLimit, 
            string country = Parameters.DefaultCountry)
            :base(limit, country)
        {
            Url = Endpoints.Lists.Dvds.TopRentalsUrl;
        }
    }
}

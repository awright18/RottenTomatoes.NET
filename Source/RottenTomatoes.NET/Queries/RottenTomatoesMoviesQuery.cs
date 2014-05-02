namespace RottenTomatoes.Queries
{
    internal abstract class RottenTomatoesMoviesQuery:RottenTomatoesQuery<MovieList>
    {
        internal RottenTomatoesMoviesQuery(int pageNumber = Parameters.DefaultPageNumber, int pageLimit = Parameters.DefaultPageLimit, string country = Parameters.DefaultCountry)
        {
            AddIntParameter(Parameters.PageNumber, pageNumber);

            AddIntParameter(Parameters.PageLimit, pageLimit);

            AddStringParameter(Parameters.Country, country);
        }

        internal RottenTomatoesMoviesQuery(int limit = Parameters.DefaultLimit, string country = Parameters.DefaultCountry)
        {
            AddIntParameter(Parameters.Limit,limit);

            AddStringParameter(Parameters.Country, country);
        }
    }
}

using System.Threading.Tasks;
using RottenTomatoes.Queries;

namespace RottenTomatoes
{
    public partial class RottenTomatoesClient
    {
        /// <summary>
        /// <para>Gets a list of top dvd rental movies.</para>
        /// <para>The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/In_Theaters_Movies" >here</see></para>
        /// <para>The api endpoint is "http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/top_rentals.json?apikey=[your_api_key]&limit=1"</para>
        /// </summary>
        /// <param name="limit">The number of results returned. The default value is 10.</param>
        /// <param name="country">The country where the movies are playing.  The default value is us.</param>
        /// <returns>A list of movies</returns>
        public async Task<MovieList> GetTopRentalMoviesAsync(
            int limit = Parameters.DefaultLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetTopRentalMoviesQuery(limit, country));
            return result;
        }

        public async Task<MovieList> GetCurrentDvdReleasesAsync(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetCurrentDvdReleasesQuery(pageNumber,pageLimit, country));
            return result;
        }

        public async Task<MovieList> GetNewDvdReleasesAsync(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetNewDvdReleasesQuery(pageNumber, pageLimit, country));
            return result;
        }

        public async Task<MovieList> GetUpcomingDvdReleasesAsync(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetUpcomingDvdReleasesQuery(pageNumber, pageLimit, country));
            return result;
        }
    }
}

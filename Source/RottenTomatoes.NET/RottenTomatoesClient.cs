using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RottenTomatoes.Model;
using RottenTomatoes.NET.Queries;
using RottenTomatoes.Queries;

namespace RottenTomatoes
{
    /// <summary>
    /// Name: RottenTomatoesClient
    /// This class is the public interface to the Rotten Tomatoes API. 
    /// </summary>
    public partial class RottenTomatoesClient
    {
#if DEBUG
        public string LastUrlCalled {
            get { return Api.LastUrlCalled; }
        }
#endif
        /// <summary>
        /// This is the version of the RottenTomatoes API that the client interacts with.
        /// </summary>
        public const string APIVersion = "1.0";

        private readonly string _apiKey;
        /// <summary>
        /// RottenTomatoesClient constructor.
        /// </summary>
        /// <param name="apiKey">Rotten Tomatoes API Key</param>
        public RottenTomatoesClient(string apiKey)
        {
            _apiKey = apiKey;
        }
        /// <summary>
        /// <para>This will get all the movie information about a movie with the given rotten tomatoes id.</para>
        /// <para>The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/Movie_Info" >here</see></para>
        /// <para>The api endpoint is "http://api.rottentomatoes.com/api/public/v1.0/movies/[movieid].json?apikey=[your_api_key]"</para>
        /// </summary>
        /// <param name="id">The id given to a particular movie by the RottenTomatoes API</param>
        /// <returns>Movie information returned from RottenTomatoes API</returns>
        public async Task<Movie> GetMovieAsync(string id)
        {
            var result = await QueryAsync(new GetMovieQuery(id));
            return result;
        }
        /// <summary>
        /// <para>This will get all the movie information about a movie with the given rotten tomatoes id.</para>
        /// <para>The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/Movie_Info" >here</see></para>
        /// <para>The api endpoint is "http://api.rottentomatoes.com/api/public/v1.0/movies/[movieid].json?apikey=[your_api_key]"</para>
        /// </summary>
        /// <param name="id">The id given to a particular movie by the RottenTomatoes API</param>
        /// <param name="includeFullCast">should the full cast be included when getting the movie</param>
        /// <param name="includeClips">should clips be included when getting the movie</param>
        /// <param name="includeReviews">should reviews be included when getting the movie</param>
        /// <param name="reviewType">The type of reviews to fetch if include reivews is true. all/top_critic/dvd</param>
        /// <returns>Movie information returned from RottenTomatoes API</returns>
        public async Task<Movie> GetMovieAsync(
            string id, 
            bool includeFullCast = false, 
            bool includeClips = false, 
            bool includeReviews = false,
            string reviewType = "all")
        {
            var movie = await QueryAsync(new GetMovieQuery(id));
            
            if (includeFullCast)
            {
                movie.FullCast = await GetMovieCastAsync(movie);
            }

            if (includeClips)
            {
                movie.Clips = await GetMovieClipsAsync(movie);
            }

            if (includeReviews)
            {
                movie.Reviews = await GetMovieReviewsAsync(movie,reviewType);
            }
            return movie;
        }


        /// <summary>
        /// Gets a list of movies currently in theaters. 
        /// The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/In_Theaters_Movies" >here</see></para>
        /// The api endpoint is http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey=[your_api_key]&amp;page_limit=1&amp;page=1&amp;country=us
        /// </summary>
        /// <param name="pageNumber">The results page number. The default value is 1.</param>
        /// <param name="pageLimit">The number of movies return per page. The default value is 16.</param>
        /// <param name="country">The country where the movies are playing.  The default value is us.</param>
        /// <returns>A list of movies</returns>
        public async Task<MovieList> GetMoviesInTheatersAsync(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetMoviesInTheatersQuery(pageNumber,pageLimit,country));
            return result;
        }
        /// <summary>
        /// Gets a list of upcoming movies. 
        /// <para>The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/Upcoming_Movies >here</see></para>
        /// <para>The api endpoint is http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?apikey=[your_api_key]&amp;page_limit=1&amp;page=1&amp;country=us<para></para>
        /// </summary>
        /// <param name="pageNumber">The results page number. The default value is 1.</param>
        /// <param name="pageLimit">The number of movies return per page. The default value is 16.</param>
        /// <param name="country">The country where the movies are playing.  The default value is us.</param>
        /// <returns>A list of movies</returns>
        public async Task<MovieList> GetUpcomingMoviesAsync(
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetUpcomingMoviesQuery(pageNumber,pageLimit, country));
            return result;
        }

        /// <summary>
        /// Gets a list of upcoming movies. 
        /// <para>The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/Box_Office_Movies"> here. </see></para>
        /// <para>The api endpoint is http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey=[your_api_key]&amp;limit=1&amp;country=us</para>
        /// </summary>
        /// <param name="limit">The number of movies return. The default value is 10.</param>
        /// <param name="country">The country where the movies are playing.  The default value is us.</param>
        /// <returns>A list of movies</returns>
        public async Task<MovieList> GetBoxOfficeMoviesAsync(
            int limit = Parameters.DefaultLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetBoxOfficeMoviesQuery(limit, country));
            return result;
        }
        /// <summary>
        /// Gets a list of upcoming movies. 
        /// <para>The api documentation is <see cref="!:http://developer.rottentomatoes.com/docs/read/json/v10/Opening_Movies"> here.</see></para>
        /// <para>The api endpoint is http://api.rottentomatoes.com/api/public/v1.0/lists/movies/opening.json?apikey=[your_api_key]&amp;limit=1&amp;country=us</para>
        /// </summary>
        /// <param name="limit">The number of movies return. The default value is 10.</param>
        /// <param name="country">The country where the movies are playing.  The default value is us.</param>
        /// <returns>A list of movies</returns>
        public async Task<MovieList> GetOpeningMoviesAsync(
            int limit = Parameters.DefaultLimit,
            string country = Parameters.DefaultCountry)
        {
            var result = await QueryAsync(new GetOpeningMoviesQuery(limit, country));
            return result;
        }
        
        //Movie Cast
        public async Task<MovieCast> GetMovieCastAsync(
            string movieId)
        {
            var cast = await Api.QueryAsync(new GetMovieCastQuery(movieId), _apiKey);
            return cast;
        }

        public async Task<MovieCast> GetMovieCastAsync(
            Movie movie)
        {
            var cast = await GetMovieCastAsync(movie.Id);
            return cast;
        }

        //Movie Clips
        public async Task<MovieClips> GetMovieClipsAsync(
            string movieId)
        {
            var clips = await Api.QueryAsync(new GetMovieClipsQuery(movieId), _apiKey);
            return clips;
        }

        public async Task<MovieClips> GetMovieClipsAsync(
          Movie movie)
        {
            var clips = await GetMovieClipsAsync(movie.Id);
            return clips;
        }

        //movie reviews
        public async Task<MovieReviews> GetMovieReviewsAsync(
            string movieId, 
            string reviewType = Parameters.DefaultMovieReviewType,
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var movieReviewsQuery = 
                new GetMovieReviewsQuery(movieId, reviewType, pageNumber, pageLimit, country);

            var reviews = await Api.QueryAsync(movieReviewsQuery, _apiKey);

            return reviews;
        }

        public async Task<MovieReviews> GetMovieReviewsAsync(
            Movie movie,
            string movieId, 
            string reviewType = Parameters.DefaultMovieReviewType,
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit,
            string country = Parameters.DefaultCountry)
        {
            var reviews = await GetMovieReviewsAsync(movie.Id,reviewType,pageNumber, pageLimit,country);
            return reviews;
        }

        public async Task<MovieList> SearchMoviesAsync(
            string queryText = "",
            int pageNumber = Parameters.DefaultPageNumber,
            int pageLimit = Parameters.DefaultPageLimit)
        {
            try
            {
                var movieList = await Api.QueryAsync(new SearchMoviesQuery(queryText, pageNumber, pageLimit),_apiKey);
                
                return movieList;
            }
            catch (Exception ex)
            {
                return new MovieList() {Movies = null, Total = 0};
            }
        }


        private async Task<T> QueryAsync<T>(RottenTomatoesQuery<T> query)
        {
            var result = await Api.QueryAsync(query, _apiKey);
            return result;
        }

    }
}

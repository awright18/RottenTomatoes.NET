using NUnit.Framework;
namespace RottenTomatoes.Net45.Test
{
    class MovieTests:ClientTest
    {
        [Test]
        public async void can_search_movies()
        {
            var movieList = await Client.SearchMoviesAsync("Toy Story 9");

            Assert.IsNotNull(movieList);
            Assert.IsTrue(movieList.Total > 0);
        }

        [Test]
        [TestCase("770672122")] //Toy Story 3
        public async void can_get_movie(string movieId)
        {
            var movie = await Client.GetMovieAsync(movieId,includeClips:true, includeFullCast:true,includeReviews: true);

            Assert.IsNotNull(movie);
        }

        [Test]
        [TestCase("770672122")] //Toy Story 3
        public async void can_get_movie_clips(string movieId)
        {
            var movieclips = await Client.GetMovieClipsAsync(movieId);

            Assert.IsNotNull(movieclips);
        }

        [Test]
        [TestCase("770672122")] //Toy Story 3
        public async void can_get_movie_reviews(string movieId)
        {
            var movieclips = await Client.GetMovieReviewsAsync(movieId,reviewType:"top_critic");

            Assert.IsNotNull(movieclips);
        }
    }
}

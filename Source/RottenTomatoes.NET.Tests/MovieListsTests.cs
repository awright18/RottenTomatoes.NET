using System.Linq;
using NUnit.Framework;

namespace RottenTomatoes.Net45.Test
{
    [TestFixture]
    class MovieListsTests : ClientTest
    {
        [Test]
        public async void can_get_box_office_movies()
        {
            var result = await Client.GetBoxOfficeMoviesAsync();
                
            IsNotNull(result);
        }

        [Test]
        [TestCase(2,1,"af")]
        public async void can_get_movies_in_theatres(int pageNumber, int pageLimit, string country)
        {
            var result = await Client.GetMoviesInTheatersAsync(pageNumber,pageLimit,country);
            var url = Client.LastUrlCalled;
            var cast = await Client.GetMovieCastAsync(result.Movies.First());
            IsNotNull(cast);
            IsNotNull(result);
        }

        [Test]
        public async void can_get_movies_opening_in_theatres()
        {
            var result = await Client.GetOpeningMoviesAsync();

            IsNotNull(result);
        }

        [Test]
        public async void can_get_movies_upcoming_in_theatres()
        {
            var result = await Client.GetUpcomingMoviesAsync();

            IsNotNull(result);
        }
    }
}

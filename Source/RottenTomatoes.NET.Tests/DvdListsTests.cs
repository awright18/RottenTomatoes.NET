using NUnit.Framework;
namespace RottenTomatoes.Net45.Test
{
    class DvdListsTests:ClientTest
    {
        [Test]
        public async void can_get_top_rental_dvds()
        {
            var result = await Client.GetTopRentalMoviesAsync();

            IsNotNull(result);
        }

        [Test]
        public async void can_get_current_release_dvds()
        {
            var result = await Client.GetCurrentDvdReleasesAsync();

            IsNotNull(result);
        }

        [Test]
        public async void can_get_new_release_dvds()
        {
            var result = await Client.GetNewDvdReleasesAsync();

            IsNotNull(result);
        }

        [Test]
        public async void can_get_upcoming_dvds()
        {
            var result = await Client.GetUpcomingDvdReleasesAsync();

            IsNotNull(result);
        }
    }
}

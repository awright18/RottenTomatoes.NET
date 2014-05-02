using System.Text;
using RottenTomatoes.Queries;

namespace RottenTomatoes
{
    internal static class Endpoints
    {
        private const string apiUrl = "http://api.rottentomatoes.com/api/public/v1.0";
        private const string listsJson = "lists.json";
        private const string moviesJson = "movies.json";
        private const string linksJson = "";

        internal static string LinksUrl = BuildUrl(linksJson);
        internal static string ListsUrl = BuildUrl(listsJson);
        internal static string MoviesUrl = BuildUrl(moviesJson);

        private const string moviesSegment = "movies";

        private static string BuildUrl(string path)
        {
            var url = JoinPath(apiUrl, path);
            return url;
        }

        internal static class Movies
        {
            private static string movieBaseUrl = JoinPath(apiUrl, moviesSegment);
            private const string similarJson = "similar.json";
            private const string castJson = "cast.json";
            private const string clipsJson = "clips.json";
            private const string reviewsJson = "reviews.json";

            internal static string GetMovieUrl(string movieId)
            {
                var movieidSegment = string.Format("{0}.json", movieId);
                var movieUrl = BuildMovieBasedUrl(movieidSegment);
                return movieUrl;
            }

            internal static string GetSimlarMoviesUrl(string movieId)
            {
                var similarMoviesUrl = BuildMovieBasedUrl(movieId, similarJson);
                return similarMoviesUrl;
            }

            internal static string GetMovieCastUrl(string movieId)
            {
                var similarMoviesUrl = BuildMovieBasedUrl(movieId, castJson);
                return similarMoviesUrl;
            }

            internal static string GetMovieClipsUrl(string movieId)
            {
                var similarMoviesUrl = BuildMovieBasedUrl(movieId, clipsJson);
                return similarMoviesUrl;
            }

            internal static string GetMovieReviewsUrl(string movieId)
            {
                var movieReviewsUrl = BuildMovieBasedUrl(movieId, reviewsJson);
                return movieReviewsUrl;
            }

            internal static string BuildMovieBasedUrl(string movieId, string path = null)
            {
                var movieBasedUrl = JoinPath(movieBaseUrl, movieId, path);
                return movieBasedUrl;
            }
        }


        internal static class Lists
        {
            static Lists ()
            {
            }
            private static string listsbaseUrl = JoinPath(apiUrl, listsSegment);

            private const string listsSegment = "lists";

            private const string dvdsJson = "dvds.json";

            internal static string MoviesUrl = BuildListsUrl(moviesJson);
            internal static string DvdsUrl = BuildListsUrl(dvdsJson);

            internal static string BuildListsUrl(string path)
            {
                var listsUrl = JoinPath(listsbaseUrl, path);

                return listsUrl;
            }

            internal static class Movies
            {
                private static string listMoviesUrl = BuildListsUrl(moviesSegment);

                private const string boxOfficeJson = "box_office.json";
                private const string inTheatersJson = "in_theaters.json";
                private const string openingJson = "opening.json";
                private const string upcomingJson = "upcoming.json";

                internal static string BoxOfficeUrl = BuildMoviesListUrl(boxOfficeJson);
                internal static string InTheatresUrl = BuildMoviesListUrl(inTheatersJson);
                internal static string OpeningUrl = BuildMoviesListUrl(openingJson);
                internal static string UpcomingUrl = BuildMoviesListUrl(upcomingJson);

                internal static string BuildMoviesListUrl(string path)
                {
                    var moviesListUrl = JoinPath(listMoviesUrl, path);

                    return moviesListUrl;
                }
            }

            internal static class Dvds
            {
                private const string dvdsSegment = "dvds";
                private static string listDvdsUrl = BuildListsUrl(dvdsSegment);

                private const string topRentalsJson = "top_rentals.json";
                private const string currentReleasesJson = "current_releases.json";
                private const string newReleasesJson = "new_releases.json";
                private const string upcomingJson = "upcoming.json";

                internal static string TopRentalsUrl = BuildDvdsListUrl(topRentalsJson);
                internal static string CurrentReleasesUrl = BuildDvdsListUrl(currentReleasesJson);
                internal static string NewReleasesUrl = BuildDvdsListUrl(newReleasesJson);
                internal static string UpcomingUrl = BuildDvdsListUrl(upcomingJson);

                internal static string BuildDvdsListUrl(string path)
                {
                    var dvdsListUrl = JoinPath(listDvdsUrl, path);

                    return dvdsListUrl;
                }
            }
        }

        private static string JoinPath(string baseUrl, params string[] segments)
        {
            var newUrl = baseUrl;

            for (int i = 0; i < segments.Length; i++)
            {
                newUrl = JoinPath(newUrl, segments[i]);
            }

            return newUrl;
        }

        private static string JoinPath(string baseurl, string segment)
        {
            if (segment == null)
            {
                return baseurl;
            }

            var newBaseUrl = RemoveEndingSlashes(baseurl);
            var newSegment = RemoveStartingForwardSlashes(segment);

            var url = newBaseUrl + "/" + newSegment;

            return url;
        }

        private static string RemoveEndingSlashes(string url)
        {
            var newUrl = url;
            
            if (url.EndsWith("/"))
            {
                newUrl = url.Remove(url.LastIndexOf("/"));
            }

            if (!newUrl.EndsWith("/"))
            {
                return newUrl;
            }

            RemoveEndingSlashes(newUrl);

            return newUrl;
        }

        private static string RemoveStartingForwardSlashes(string segment)
        {
            var newSegment = segment;
            
            if (segment.StartsWith("/"))
            {
                newSegment = segment.Remove(segment.IndexOf("/"));
            }

            if (!newSegment.StartsWith("/"))
            {
                return newSegment;
            }

            RemoveStartingForwardSlashes(newSegment);

            return newSegment;
        }
    }
}

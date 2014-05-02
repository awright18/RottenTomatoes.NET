using RottenTomatoes.Model;

namespace RottenTomatoes.Queries
{
    internal sealed class GetMovieCastQuery : RottenTomatoesQuery<MovieCast>
    {
        internal GetMovieCastQuery(string movieId)
        {
            Url = Endpoints.Movies.GetMovieCastUrl(movieId);
        }
    }
}

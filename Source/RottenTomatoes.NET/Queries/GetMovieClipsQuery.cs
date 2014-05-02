using RottenTomatoes.Model;

namespace RottenTomatoes.Queries
{
    internal sealed class GetMovieClipsQuery : RottenTomatoesQuery<MovieClips>
    {
        internal GetMovieClipsQuery(string movieId)
        {
            Url = Endpoints.Movies.GetMovieClipsUrl(movieId);
        }
    }
}

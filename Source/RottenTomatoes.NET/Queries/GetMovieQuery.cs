namespace RottenTomatoes.Queries
{
    internal sealed class GetMovieQuery:RottenTomatoesQuery<Movie>
    {
        internal GetMovieQuery(string id)
        {
            Url = Endpoints.Movies.GetMovieUrl(id);
        }
    }
}

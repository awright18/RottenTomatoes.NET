using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RottenTomatoes.NET.Queries
{
    internal sealed class SearchMoviesQuery:RottenTomatoesQuery<MovieList>
    {
        internal SearchMoviesQuery(
            string queryText ="",
            int pageNumber = Parameters.DefaultPageNumber, 
            int pageLimit = Parameters.DefaultPageLimit)
        {
            Url = Endpoints.MoviesUrl;

            var _queryText = HttpUtility.UrlEncode(queryText);

            AddStringParameter(Parameters.Query, _queryText);
            AddIntParameter(Parameters.PageLimit,pageLimit);
            AddIntParameter(Parameters.PageNumber, pageNumber);
        }
    }
}

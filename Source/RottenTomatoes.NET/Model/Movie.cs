using System.Collections.Generic;
using RottenTomatoes.Model;
using RottenTomatoes.Queries;

namespace RottenTomatoes
{
    public sealed class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string[] Genres { get;set;}
        public int? Runtime { get; set; }
        public string Mpaa_Rating { get; set; }
        public string Critics_Consensus { get; set; }
        public string Synopsis { get; set; }
        public string Studio { get; set; }
        public string Thumbnail {
            get { return Posters != null ?  Posters.ThumbNail : ""; }
        }
        public MoviePosters Posters { get;  set; }
        public MovieReleaseDates Release_Dates { get; set; }
        public MovieRatings Ratings { get; set; }
        public Actor[] Abridged_Cast { get; set; }
        public MovieCast FullCast { get; internal set; }
        public MovieClips Clips { get; internal set; }
        public MovieReviews Reviews { get; internal set; }
    }

}

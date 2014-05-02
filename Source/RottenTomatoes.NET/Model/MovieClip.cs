using System.Collections.Generic;

namespace RottenTomatoes.Model
{
    public sealed class MovieClip
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Thumbnail { get; set; }
        public MovieClipLink Links { get; set; }
    }
}

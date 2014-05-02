namespace RottenTomatoes.Model
{
    public sealed class MovieReview
    {
        public string Critic { get; set; }
        public string Date { get; set; }
        public string Pulbication { get; set; }
        public string Quote { get; set; }
        public ReviewLink Links { get;set;} 
    }
}

namespace MovieAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public DateTime? MovieReleaseDate { get; set; }
        public Cinema? cinema { get; set; }
        public Category? category { get; set; }
    }
}
namespace MovieAPI.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string? CinemaName { get; set; }
        public int CinemaPlaceholder { get; set; }
        public List<Movie>? movies { get; set; }
    }
}

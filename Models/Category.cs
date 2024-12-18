namespace MovieAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Movie>? movies { get; set; }
    }
}

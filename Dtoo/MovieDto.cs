using MovieAPI.Dtoo;

namespace MovieAPI.Dtoo
{
    public class MovieDto
    {
        public string? MovieTitleDto { get; set; }
        public DateTime? MovieReleaseDateDto { get; set; }
        public CategoryDto? categoryDto { get; set; }
    }
}

public class AddAllMovieDto
{
    public string? MovieTitleDto { get; set; }
    public DateTime? MovieReleaseDateDto { get; set; }
    public CinemaDto? cinemaDto { get; set; }
    public CategoryDto? categoryDto { get; set; }
}
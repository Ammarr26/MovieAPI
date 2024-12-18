using MovieAPI.Dtoo;

namespace MovieAPI.Dtoo
{
    public class CinemaDto
    {
        public string? CinemaNameDto { get; set; }
        public int CinemaPlaceholderDto { get; set; }
    }
}
public class AddAllCinemaDto
{
    public string? CinemaNameDto { get; set; }
    public int CinemaPlaceholderDto { get; set; }
    public List<MovieDto>? movieDtos { get; set; }
}
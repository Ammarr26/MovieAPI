using MovieAPI.DB;
using MovieAPI.Dtoo;
using MovieAPI.Interface;
using MovieAPI.Models;

namespace MovieAPI.Repository
{
    public class CinemaRepo : ICinema
    {
        private readonly AppDbContext _context;
        public CinemaRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddAllCinema(AddAllCinemaDto addAllCinemaDto)
        {
            Cinema cinema = new Cinema
            {
                CinemaName = addAllCinemaDto.CinemaNameDto,
                CinemaPlaceholder = addAllCinemaDto.CinemaPlaceholderDto,
                movies = addAllCinemaDto.movieDtos.Select(movie => new Movie
                {
                    MovieTitle = movie.MovieTitleDto,
                    MovieReleaseDate = movie.MovieReleaseDateDto,
                    category = new Category
                    {
                        CategoryName = movie.categoryDto.CategoryNameDto
                    }
                }).ToList(),
            };
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }

        public List<AddAllCinemaDto> GetAllCinema()
        {
            var result = _context.Cinemas.Select(x => new AddAllCinemaDto
            {
                CinemaNameDto = x.CinemaName,
                CinemaPlaceholderDto = x.CinemaPlaceholder,
                movieDtos = x.movies.Select(movie => new MovieDto
                {
                    MovieTitleDto = movie.MovieTitle,
                    MovieReleaseDateDto = movie.MovieReleaseDate,
                    categoryDto = new CategoryDto
                    {
                        CategoryNameDto = movie.category.CategoryName
                    },
                }).ToList(),
            }).ToList();
            return result;
        }

        public void UpdateCinema(int id, AddAllCinemaDto addAllCinemaDto)
        {
            var result = _context.Cinemas.FirstOrDefault(x => x.CinemaId == id);
            if (result != null)
            {
                result.CinemaName = addAllCinemaDto.CinemaNameDto;
                result.CinemaPlaceholder = addAllCinemaDto.CinemaPlaceholderDto;
                result.movies = addAllCinemaDto.movieDtos.Select(x => new Movie
                {
                    MovieTitle = x.MovieTitleDto,
                    MovieReleaseDate = x.MovieReleaseDateDto,
                    category = new Category
                    {
                        CategoryName = x.categoryDto.CategoryNameDto,
                    }
                }).ToList();
            }
            _context.Cinemas.Update(result);
            _context.SaveChanges();
        }
    }
}
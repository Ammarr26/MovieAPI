using Microsoft.EntityFrameworkCore;
using MovieAPI.DB;
using MovieAPI.Dtoo;
using MovieAPI.Interface;
using MovieAPI.Models;

namespace MovieAPI.Repository
{
    public class MovieRepo : IMovie
    {
        private readonly AppDbContext _context;
        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddAllMovie(AddAllMovieDto addAllMovieDto)
        {
            Movie movie = new Movie
            {
                MovieTitle = addAllMovieDto.MovieTitleDto,
                MovieReleaseDate = addAllMovieDto.MovieReleaseDateDto,
                cinema = new Cinema
                {
                    CinemaName = addAllMovieDto.cinemaDto.CinemaNameDto,
                    CinemaPlaceholder = addAllMovieDto.cinemaDto.CinemaPlaceholderDto
                },
                category = new Category
                {
                    CategoryName = addAllMovieDto.categoryDto.CategoryNameDto,
                }

            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public AddAllMovieDto GetMovieById(int id)
        {
            var result = _context.Movies.Include(x => x.cinema).Include(x => x.category).FirstOrDefault(x => x.MovieId == id);
            var addAllMovieDto = new AddAllMovieDto
            {
                MovieTitleDto = result.MovieTitle,
                MovieReleaseDateDto = result.MovieReleaseDate,
                cinemaDto = new CinemaDto
                {
                    CinemaNameDto = result.cinema.CinemaName,
                    CinemaPlaceholderDto = result.cinema.CinemaPlaceholder,
                },
                categoryDto = new CategoryDto
                {
                    CategoryNameDto = result.category.CategoryName
                }
            };
            return addAllMovieDto;
        }
        public List<AddAllMovieDto> GetAllMovie()
        {
            var result = _context.Movies.Include(x => x.cinema).Include(x => x.category).Select(m => new AddAllMovieDto
            {
                MovieTitleDto = m.MovieTitle,
                MovieReleaseDateDto = m.MovieReleaseDate,
                cinemaDto = new CinemaDto
                {
                    CinemaNameDto = m.cinema.CinemaName,
                    CinemaPlaceholderDto = m.cinema.CinemaPlaceholder,
                },
                categoryDto = new CategoryDto
                {
                    CategoryNameDto = m.category.CategoryName
                }
            }).ToList();
            return result;
        }
    }
}
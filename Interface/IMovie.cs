namespace MovieAPI.Interface
{
    public interface IMovie
    {
        public void AddAllMovie(AddAllMovieDto addAllMovieDto);
        public AddAllMovieDto GetMovieById(int id);
        public List<AddAllMovieDto> GetAllMovie();
    }
}
namespace MovieAPI.Interface
{
    public interface ICinema
    {
        public void AddAllCinema(AddAllCinemaDto addAllCinemaDto);
        public List<AddAllCinemaDto> GetAllCinema();
        public void UpdateCinema(int id, AddAllCinemaDto addAllCinemaDto);
    }
}
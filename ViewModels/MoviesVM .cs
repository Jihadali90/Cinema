namespace Cinema_APP.ViewModels
{
    public class MoviesVM
    {
        public IEnumerable<Movie> Movies{ get; set; }

        public double TotalPages { get; set; }

        public int CurrentPage { get; set; }

    }
}

namespace Cinema_APP.ViewModels
{
    public class CinemaVM
    {
        public IEnumerable<Cinema> cinemas { get; set; }

        public double TotalPages { get; set; }

        public int CurrentPage { get; set; }

    }
}

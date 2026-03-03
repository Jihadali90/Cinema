namespace Cinema_APP.Models
{
    public class Movie_cinema
    {
        public int Id { get; set; }
        public int Movie_Id { get; set; }
        public int Cinema_Id { get; set; }


        public Movie? Movie { get; set; }
        public Cinema? Cinema { get; set; }
    }
}

namespace Cinema_APP.ViewModels
{
    public class Movie_actors
    {
        public int Id { get; set; }
        public int Actor_Id { get; set; } 
        public int Movie_Id { get; set; } 

       // public Actor? Actor { get; set; }
        public Movie? Movie { get; set; }
    }
}

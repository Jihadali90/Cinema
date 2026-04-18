namespace Cinema_APP.ViewModels
{
    public class MoviewithRelatedVM
    {
        public Movie Movie { get; set; }
        public List<Movie> relatedMovies { get; set; }
        public List<Movie> RelatedPrices { get; set; }



    }
}

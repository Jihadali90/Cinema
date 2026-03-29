namespace Cinema_APP.ViewModels
{
    public class Movie_subImg
    {
        public int Id { get; set; }
        public string Sub_Img { get; set; } = string.Empty;
        public int Movie_Id { get; set; }
        public Movie? Movie { get; set; }
    }
}

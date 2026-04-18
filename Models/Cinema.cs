namespace Cinema_APP.ViewModels
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Main_Img { get; set; } 
        public string Location{ get; set; } = string.Empty;

        public bool status { get; set; }
    }
}

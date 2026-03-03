namespace Cinema_APP.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location{ get; set; } = string.Empty;

        public bool status { get; set; }
    }
}

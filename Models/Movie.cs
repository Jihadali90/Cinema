namespace Cinema_APP.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public bool Status { get; set; }
        public string Actors { get; set; } = string.Empty;
        public decimal Price{ get; set; } 
        public decimal? Discount { get; set; }
        public int? Quantity { get; set; } 
        public double Rate { get; set; } = 0;

        public string Main_Img { get; set; } = string.Empty;
        public DateTime Show_Time { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
    }
}

using Cinema_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_APP.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie_subImg> Movie_SubImgs { get; set; }
        public DbSet<Movie_actors> Movie_Actors { get; set; }
        public DbSet<Movie_cinema> Movie_Cinemas { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
        "Data Source=localhost\\JIHAD_ALY;Initial Catalog=Cinema_APP;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

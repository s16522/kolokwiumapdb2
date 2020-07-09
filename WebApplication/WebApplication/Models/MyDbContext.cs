using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class MyDbContext : DbContext
    {
        
        public MyDbContext() {}

        public MyDbContext(DbContextOptions options) : base(options) {}
        
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Art_Movement> ArtMovements { get; set; }
    }
}
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGamesDetails => Set<VideoGameDetails>();
        public DbSet<Genre> Genre => Set<Genre>();
        public DbSet<Developer> Developer => Set<Developer>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Review> Reviews => Set<Review>(); 
        public DbSet<Platform> Platforms => Set<Platform>();

        public DbSet<Publisher> Publisher => Set<Publisher>();

    }

    
}

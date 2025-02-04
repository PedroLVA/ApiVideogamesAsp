using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGamesDetails => Set<VideoGameDetails>();
        public DbSet<Genre> Genre => Set<Genre>();
        public DbSet<Publisher> Publishers => Set<Publisher>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
            new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild"},
            new VideoGame { Id = 2, Title = "God of War", Platform = "PlayStation 4"},
            new VideoGame { Id = 3, Title = "Cyberpunk 2077", Platform = "PC, PlayStation, Xbox"},
            new VideoGame { Id = 4, Title = "Halo Infinite", Platform = "Xbox, PC"},
            new VideoGame { Id = 5, Title = "Red Dead Redemption 2", Platform = "PlayStation, Xbox, PC" });
        }
    }

    
}

using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGamesDetails => Set<VideoGameDetails>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
            new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
            new VideoGame { Id = 2, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
            new VideoGame { Id = 3, Title = "Cyberpunk 2077", Platform = "PC, PlayStation, Xbox", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
            new VideoGame { Id = 4, Title = "Halo Infinite", Platform = "Xbox, PC", Developer = "343 Industries", Publisher = "Xbox Game Studios" },
            new VideoGame { Id = 5, Title = "Red Dead Redemption 2", Platform = "PlayStation, Xbox, PC", Developer = "Rockstar Games", Publisher = "Rockstar Games" });
        }
    }

    
}

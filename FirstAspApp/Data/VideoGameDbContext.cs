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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Platforms
            var pc = new Platform { Id = 1, Name = "PC", Company = "Microsoft" };
            var ps4 = new Platform { Id = 2, Name = "PlayStation 4", Company = "Sony" };
            var ps5 = new Platform { Id = 3, Name = "PlayStation 5", Company = "Sony" };
            var xbox = new Platform { Id = 4, Name = "Xbox", Company = "Microsoft" };
            var switchPlatform = new Platform { Id = 5, Name = "Nintendo Switch", Company = "Nintendo" };

            modelBuilder.Entity<Platform>().HasData(pc, ps4, ps5, xbox, switchPlatform);

            // Seeding VideoGames
            var zelda = new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild" };
            var godOfWar = new VideoGame { Id = 2, Title = "God of War" };
            var cyberpunk = new VideoGame { Id = 3, Title = "Cyberpunk 2077" };
            var halo = new VideoGame { Id = 4, Title = "Halo Infinite" };
            var rdr2 = new VideoGame { Id = 5, Title = "Red Dead Redemption 2" };

            modelBuilder.Entity<VideoGame>().HasData(zelda, godOfWar, cyberpunk, halo, rdr2);

            // Seeding VideoGame - Platform Relationships
            modelBuilder.Entity("PlatformVideoGame").HasData(
                new { PlatformsId = 5, VideoGamesId = 1 }, // Zelda -> Switch
                new { PlatformsId = 2, VideoGamesId = 2 }, // God of War -> PlayStation 4
                new { PlatformsId = 1, VideoGamesId = 3 }, // Cyberpunk -> PC
                new { PlatformsId = 3, VideoGamesId = 3 }, // Cyberpunk -> PlayStation 5
                new { PlatformsId = 4, VideoGamesId = 3 }, // Cyberpunk -> Xbox
                new { PlatformsId = 4, VideoGamesId = 4 }, // Halo -> Xbox
                new { PlatformsId = 1, VideoGamesId = 4 }, // Halo -> PC
                new { PlatformsId = 2, VideoGamesId = 5 }, // RDR2 -> PlayStation 4
                new { PlatformsId = 4, VideoGamesId = 5 }, // RDR2 -> Xbox
                new { PlatformsId = 1, VideoGamesId = 5 }  // RDR2 -> PC
            );
        }
    }

    
}

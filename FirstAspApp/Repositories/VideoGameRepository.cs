using System;
using FirstAspApp.Data;
using FirstAspApp.DTOs.VideoGameDTOs;
using FirstAspApp.Interfaces;
using FirstAspApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspApp.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {


        private readonly VideoGameDbContext _context;

        public VideoGameRepository(VideoGameDbContext context)
        {
            _context = context;
        }

        public async Task AddGenreToVideoGame(int genreId, int videoGameId)
        {
            var foundVideoGame = await _context.VideoGames.Include(vg => vg.Genres).FirstOrDefaultAsync(vg => vg.Id == videoGameId);
            var foundGenre = await _context.Genre.FindAsync(genreId);

            if (foundGenre == null || foundVideoGame == null)
            {
                throw new Exception("Videogame or Genre not found");
            }

            if(foundVideoGame.Genres.Count == 0)
            {
                foundVideoGame.Genres = new List<Genre>();
            }

            if (foundVideoGame.Genres.Any(g => g.Id == genreId))
            {
                throw new Exception("Genre already registered in the specified VideoGame");
            }

            foundVideoGame.Genres.Add(foundGenre);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task AddPlatformToVideoGame(int videoGameId, int platformId)
        {
            var foundVideoGame = await _context.VideoGames
         .Include(vg => vg.Platforms) 
         .FirstOrDefaultAsync(vg => vg.Id == videoGameId);

            var foundPlatform = await _context.Platforms.FindAsync(platformId);

            if(foundVideoGame == null || foundPlatform == null)
            {
                throw new Exception("VideoGame or Platform not found");
            }

            if (foundVideoGame.Platforms == null) 
            {
                foundVideoGame.Platforms = new List<Platform>();
            }


            if (foundVideoGame.Platforms.Any(p => p.Id == platformId))
            {
                throw new Exception("Platform already registered in the specified VideoGame");
            }


            foundVideoGame.Platforms.Add(foundPlatform);

            await _context.SaveChangesAsync();
        }


        public async Task<VideoGame> AddVideoGame(VideoGamePostDTO videoGameDto)
        {
            // Validate Developer
            var developer = await _context.Developer.FindAsync(videoGameDto.DeveloperId);
            if (developer == null)
            {
                throw new Exception("Developer not found.");
            }

            // Validate Publisher
            var publisher = await _context.Publisher.FindAsync(videoGameDto.PublisherId);
            if (publisher == null)
            {
                throw new Exception("Publisher not found.");
            }

            // Fetch existing Genres
            var existingGenres = await _context.Genre
                .Where(g => videoGameDto.GenreIds.Contains(g.Id))
                .ToListAsync();

            if (existingGenres.Count != videoGameDto.GenreIds.Count)
            {
                throw new Exception("One or more Genre IDs are invalid.");
            }

            // Fetch existing Platforms
            var existingPlatforms = await _context.Platforms
                .Where(p => videoGameDto.PlatformIds.Contains(p.Id))
                .ToListAsync();

            if (existingPlatforms.Count != videoGameDto.PlatformIds.Count)
            {
                throw new Exception("One or more Platform IDs are invalid.");
            }

            // Create the VideoGame entity
            var videoGame = new VideoGame
            {
                Title = videoGameDto.Title,
                DeveloperId = videoGameDto.DeveloperId,
                PublisherId = videoGameDto.PublisherId,
                Genres = existingGenres,
                Platforms = existingPlatforms,
                VideoGameDetails = new VideoGameDetails
                {
                    Description = videoGameDto.Description,
                    ReleaseDate = (DateTime)videoGameDto.ReleaseDate
                }
            };

            // Save the new game
            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();

            return videoGame;
        }

        public async Task DeleteVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            if (videoGame == null)
            {
                return; 
            }


            _context.VideoGames.Remove(videoGame);
            await _context.SaveChangesAsync();

            return;


        }

        public async Task<List<VideoGame>> GetAllVideoGames()
        {
            return await _context.VideoGames
                .Include(vg => vg.VideoGameDetails)
                .Include(vg => vg.Publisher)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genres)
                .Include(vg => vg.Platforms)
                .Include(vg => vg.Reviews)
                .ToListAsync();
        }

        public async Task<VideoGame?> GetVideoGameById(int id)
        {
            var VideoGame = await _context.VideoGames
               .Include(vg => vg.VideoGameDetails)
               .Include(vg => vg.Publisher)
               .Include(vg => vg.Developer)
               .Include(vg => vg.Genres)
               .Include(vg => vg.Platforms)
               .Include(vg => vg.Reviews)
               .FirstOrDefaultAsync(vg => vg.Id == id);

            return VideoGame;
        }

        public async Task<List<VideoGame>> GetVideoGamesByGenre(string genreName)
        {
            var listOfVideoGames = await _context.VideoGames.Where(vg => vg.Genres.Any(g => g.Name == genreName)).Include(vg => vg.Genres).ToListAsync();
            
            return listOfVideoGames;
        }

        public async Task UpdateVideoGame(VideoGame videoGame)
        {
            var VideoGameToUpdate = await _context.VideoGames.FindAsync(videoGame.Id);
            if(VideoGameToUpdate == null)
            {
                throw new Exception("VideoGame not found");
            }

            VideoGameToUpdate.Title = videoGame.Title;
            VideoGameToUpdate.Platforms = videoGame.Platforms;
            VideoGameToUpdate.DeveloperId = videoGame.DeveloperId;
            VideoGameToUpdate.PublisherId = videoGame.PublisherId;

            await _context.SaveChangesAsync();

            return;
        }

    }
}

using FirstAspApp.DTOs.GenreDTOs;
using FirstAspApp.Models;

namespace FirstAspApp.DTOs.VideoGameDTOs
{
    public class VideoGameGetResponseDTO
    {

        public int Id { get; set; }

        public string? Title { get; set; }

        public int? DeveloperId { get; set; }

        public int? PublisherId { get; set; }

        public List<GenreDTO>? Genres { get; set; }

        public List<String>? PlatformNames { get; set; }

        public List<Review>? Reviews { get; set; }

        public VideoGameGetResponseDTO(VideoGame videoGame) {

            Id = videoGame.Id;
            Title = videoGame.Title;
            PlatformNames = videoGame.Platforms?.Select(p => p.Name).ToList() ?? new List<string>();
            DeveloperId = videoGame.DeveloperId;
            PublisherId = videoGame.PublisherId;
            Reviews = videoGame.Reviews;
            Genres = videoGame.Genres?.Select(g => new GenreDTO(g)).ToList();
        }

    }
}

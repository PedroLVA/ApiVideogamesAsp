using FirstAspApp.Models;

namespace FirstAspApp.DTOs.VideoGameDTOs
{
    public class VideoGameGetResponseDTO
    {

        public int Id { get; set; }

        public string? Title { get; set; }

        public int? DeveloperId { get; set; }

        public int? PublisherId { get; set; }

        public List<Genre>? Genres { get; set; }

        public List<String>? PlatformNames { get; set; }

        public VideoGameGetResponseDTO(VideoGame videoGame) {

            Id = videoGame.Id;
            Title = videoGame.Title;
            PlatformNames = videoGame.Platforms?.Select(p => p.Name).ToList() ?? new List<string>();
            DeveloperId = videoGame.DeveloperId;
            PublisherId = videoGame.PublisherId;
            Genres = videoGame.Genres;
        }

    }
}

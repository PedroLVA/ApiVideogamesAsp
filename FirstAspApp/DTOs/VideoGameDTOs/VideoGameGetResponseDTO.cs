using FirstAspApp.Models;

namespace FirstAspApp.DTOs.VideoGameDTOs
{
    public class VideoGameGetResponseDTO
    {

        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Platform { get; set; }

        public int? DeveloperId { get; set; }

        public int? PublisherId { get; set; }

        public List<Genre>? Genres { get; set; }

    }
}

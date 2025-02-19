namespace FirstAspApp.DTOs.VideoGameDTOs
{
    public class VideoGamePostDTO
    {
        public string Title { get; set; } = string.Empty;

        public int DeveloperId { get; set; }

        public int PublisherId { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public List<int> GenreIds { get; set; } = new();

        public List<int> PlatformIds { get; set; } = new();
    }
}

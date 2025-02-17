namespace FirstAspApp.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public required string Name { get; set; }  // (e.g., PC, PlayStation, Xbox, Switch)
        public required string Company { get; set; }

        public List<VideoGame>? VideoGames { get; set; }

    }
}

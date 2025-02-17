using System.Text.Json.Serialization;

namespace FirstAspApp.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public required string Name { get; set; }  // (e.g., PC, PlayStation, Xbox, Switch)
        public required string Company { get; set; }

        [JsonIgnore]
        public List<VideoGame>? VideoGames { get; set; }

    }
}

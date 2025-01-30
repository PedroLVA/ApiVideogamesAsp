namespace FirstAspApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<VideoGame>? ListOfVideogames { get; set; }



    }
}

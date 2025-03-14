﻿namespace FirstAspApp.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int? DeveloperId { get; set; }

        public Developer? Developer { get; set; }
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public VideoGameDetails? VideoGameDetails { get; set; }

        public List<Genre>? Genres { get; set; }

        public List<Review>? Reviews { get; set; }

        public List<Platform>? Platforms { get; set; }

    }
}

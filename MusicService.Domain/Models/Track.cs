﻿namespace MusicService.Domain.Models
{
    public class Track : EntityBase
    {
        public string Name { get; set; }
        public Album Album { get; set; }
        public long DurationMs { get; set; }
        public bool Explicit { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
    }
}
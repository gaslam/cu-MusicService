using System;

namespace MusicService.Domain.DTO
{
    public class TrackDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long DurationMs { get; set; }
        public bool Explicit { get; set; }
        public long TrackNumber { get; set; }
        public int DiscNumber { get; set; }
    }
}
using System;

namespace MusicService.Domain.DTO
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Picture { get; set; }
    }
}

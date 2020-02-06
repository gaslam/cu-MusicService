using System;

namespace MusicService.Domain.DTO
{
    public class AlbumWithArtistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public string Artist { get; set; }
    }
}

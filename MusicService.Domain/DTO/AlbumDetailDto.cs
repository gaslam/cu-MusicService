using System;
using System.Collections.Generic;

namespace MusicService.Domain.DTO
{
    public class AlbumDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public string Artist { get; set; }
        public ICollection<TrackDto> Tracks { get; set; }
    }
}

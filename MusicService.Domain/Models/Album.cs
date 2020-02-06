using System;
using System.Collections.Generic;

namespace MusicService.Domain.Models
{
    public class Album : EntityBase
    {
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public Uri AlbumCover { get; set; }
    }
}

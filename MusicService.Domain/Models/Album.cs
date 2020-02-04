using System;
using System.Collections.Generic;

namespace MusicService.Domain.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Track> Tracks { get; set; }
        public Uri AlbumCover { get; set; }
    }
}

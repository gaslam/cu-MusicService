using System;
using System.Collections.Generic;

namespace MusicService.Domain.Models
{
    public class Artist : EntityBase
    {
        public string Name { get; set; }
        public long Followers { get; set; }
        public Uri ImagePath { get; set; }
        public ICollection<ArtistGenre> ArtistGenres { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MusicService.Domain.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}

using System;

namespace MusicService.Domain.Models
{
    public class ArtistGenre
    {
        public Guid ArtistId { get; set; }
        public Guid GenreId { get; set; }
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
    }
}

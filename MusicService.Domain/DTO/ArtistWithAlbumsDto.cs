using System;
using System.Collections.Generic;

namespace MusicService.Domain.DTO
{
    public class ArtistWithAlbumsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Picture { get; set; }
        public ICollection<AlbumDto> Albums { get; set; }
    }
}

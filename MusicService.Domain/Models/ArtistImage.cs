using System;
using System.Collections.Generic;
using System.Text;

namespace MusicService.Domain.Models
{
    public class ArtistImage
    {
        public Guid ArtistId { get; set; }
        public Guid ImageId { get; set; }

        public Artist Artist { get; set; }
        public Image Image { get; set; }
    }
}

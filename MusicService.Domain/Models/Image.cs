using System;

namespace MusicService.Domain.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public int Height { get; set; }
        public Uri Url { get; set; }
        public int Width { get; set; }
    }
}

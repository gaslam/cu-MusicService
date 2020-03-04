using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Interfaces
{
    public interface IImageService
    {
        public Task<Uri> SaveImage(IFormFile formFile, string NewImageName);
    }
}

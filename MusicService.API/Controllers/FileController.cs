using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", formFile.FileName);

            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            return Ok(new { count = 1, formFile.Length });
        }
    }
}
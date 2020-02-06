using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumRepository repository;

        public AlbumsController(AlbumRepository albumRepository)
        {
            repository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            return Ok(await repository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var model = await repository.GetById(id);

            if (model == null)
            {
                return NotFound($"Album with {id} was not found!");
            }
            return Ok(model);
        }
    }
}
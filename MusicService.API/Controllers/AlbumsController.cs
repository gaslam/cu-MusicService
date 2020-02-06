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
            return Ok(await repository.ListDtoAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(string id)
        {
            var model = await repository.GetDtoByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Album with {id} was not found!");
            }
            return Ok(model);
        }


        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetTracksByAlbumIdAsync(string id)
        {
            var model = await repository.GetDetailDtoById(id);
            if (model == null)
            {
                return NotFound($"Album with {id} was not found!");
            }
            return Ok(model);
        }
    }
}
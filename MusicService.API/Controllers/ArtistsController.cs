using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistRepository _artistRepository;

        public ArtistsController(ArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            return Ok(await _artistRepository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var artist = await _artistRepository.GetById(id);

            if (artist == null)
            {
                return NotFound($"Artist with {id} was not found!");
            }
            return Ok(artist);
        }
    }
}
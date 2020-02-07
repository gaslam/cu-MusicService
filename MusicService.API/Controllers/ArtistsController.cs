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
            return Ok(await _artistRepository.ListDtoAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var artist = await _artistRepository.GetDtoByIdAsync(id);

            if (artist == null)
            {
                return NotFound($"Artist with {id} was not found!");
            }
            return Ok(artist);
        }


        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAlbumsByArtistIdAsync(string id)
        {
            var artist = await _artistRepository.GetAlbumsByArtistIdAsync(id);

            if (artist == null)
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }

            return Ok(artist);
        }
    }
}
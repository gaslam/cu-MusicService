using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistRepository repository;

        public ArtistsController(ArtistRepository artistRepository)
        {
            repository = artistRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            return Ok(await repository.ListDtoAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var model = await repository.GetDtoByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Artist with {id} was not found!");
            }
            return Ok(model);
        }


        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAlbumsByArtistIdAsync(string id)
        {
            var model = await repository.GetAlbumsByArtistIdAsync(id);

            if (model == null)
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }

            return Ok(model);
        }
    }
}
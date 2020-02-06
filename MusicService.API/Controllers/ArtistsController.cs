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
            return Ok(await repository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var model = await repository.GetById(id);

            if (model == null)
            {
                return NotFound($"Artist with {id} was not found!");
            }
            return Ok(model);
        }
    }
}
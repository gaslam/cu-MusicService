using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreRepository repository;

        public GenresController(GenreRepository genreRepository)
        {
            repository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await repository.ListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(string id)
        {
            var model = await repository.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound($"Genre with id {id} was not found!");
            }

            return Ok(model);
        }
    }
}
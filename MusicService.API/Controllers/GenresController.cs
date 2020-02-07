using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreRepository _genreRepository;

        public GenresController(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await _genreRepository.ListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(string id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound($"Genre with id {id} was not found!");
            }

            return Ok(genre);
        }
    }
}
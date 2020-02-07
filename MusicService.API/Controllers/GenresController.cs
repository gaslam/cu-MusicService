using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using MusicService.Domain.Models;
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

        [HttpPost]
        public async Task<IActionResult> PostGenre([FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _genreRepository.Add(genre);

            return CreatedAtAction("GetGenreById", new { id = genre.Id }, genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre([FromRoute] string id, [FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id.ToString())
            {
                return BadRequest();
            }

            Genre updatedGenre = await _genreRepository.Update(genre);

            if (updatedGenre == null)
            {
                return NotFound($"Genre was not found");
            }

            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = await _genreRepository.Delete(id);
            if (genre == null)
            {
                return NotFound($"Genre with id {id} was not found");
            }

            return Ok(genre);
        }
    }
}
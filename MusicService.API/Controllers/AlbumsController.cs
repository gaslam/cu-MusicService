using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumRepository _albumRepository;

        public AlbumsController(AlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            return Ok(await _albumRepository.ListDtoAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(string id)
        {
            var album = await _albumRepository.GetDtoByIdAsync(id);

            if (album == null)
            {
                return NotFound($"Album with {id} was not found!");
            }
            return Ok(album);
        }


        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetAlbumAndTracksByAlbumIdAsync(string id)
        {
            var album = await _albumRepository.GetDetailDtoById(id);
            if (album == null)
            {
                return NotFound($"Album with {id} was not found!");
            }
            return Ok(album);
        }
    }
}
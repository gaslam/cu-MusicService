using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using System;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly MusicServiceContext _musicServiceContext;

        public AlbumsController(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            var album = await _musicServiceContext.Albums.ToListAsync();
            return Ok(album);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(string id)
        {
            var album = await _musicServiceContext.Albums.FindAsync(Guid.Parse(id));

            if (album != null)
            {
                return Ok(album);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }


        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetAlbumAndTracksByAlbumId(string id)
        {
            var album = await _musicServiceContext.Albums.Include(a => a.Tracks).SingleOrDefaultAsync(a => a.Id.ToString() == id);

            if (album != null)
            {
                return Ok(album);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }
    }
}
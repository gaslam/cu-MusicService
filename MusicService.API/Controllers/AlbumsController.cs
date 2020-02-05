using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        MusicServiceContext _context;

        public AlbumsController(MusicServiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAlbumsAsync()
        {
            var model = await _context.Albums.ToListAsync();
            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(string id)
        {
            var model = await _context.Albums.FindAsync(Guid.Parse(id));

            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }


        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetTracksByAlbumIdAsync(string id)
        {
            var model = await _context.Tracks.Include(t => t.Album).Where(a => a.Album.Id.ToString() == id).ToListAsync();

            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }
    }
}
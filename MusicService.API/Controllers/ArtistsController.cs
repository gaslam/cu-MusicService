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
    public class ArtistsController : ControllerBase
    {
        MusicServiceContext _context;

        public ArtistsController(MusicServiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetArtistsAsync()
        {
            var model = await _context.Artists.ToListAsync();
            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistByIdAsync(string id)
        {
            var model = await _context.Artists.FindAsync(Guid.Parse(id));

            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound($"Artist with {id} was not found!");
            }
        }


        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAlbumsByArtistIdAsync(string id)
        {
            var model = await _context.Albums.Include(a =>a.Artist).Where(a => a.Artist.Id.ToString() == id).ToListAsync();

            if (model.Count > 0)
            {
                return Ok(model);
            }
            else
            {
                return NotFound($"No albums found for artist with id: '{id}'");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.DTO;
using System;
using System.Collections.Generic;
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
            var model = await _context.Albums
                .Include(a => a.Artist)
                .Select(a => new AlbumWithArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ArtistId = a.Artist.Id,
                    Artist = a.Artist.Name
                })
                .ToListAsync();
            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(string id)
        {
            var model = await _context.Albums.Include(a => a.Artist).FirstOrDefaultAsync(a => a.Id == Guid.Parse(id));

            if (model != null)
            {
                var dto = new AlbumWithArtistDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    ArtistId = model.Artist.Id,
                    Artist = model.Artist.Name
                };
                return Ok(dto);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }


        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetTracksByAlbumIdAsync(string id)
        {
            var model = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.Id.ToString() == id);

            if (model != null)
            {
                var dto = new AlbumDetailDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    ArtistId = model.Artist.Id,
                    Artist = model.Artist.Name,
                    Tracks = new List<TrackDto>()
                };

                foreach (var track in model.Tracks)
                {
                    dto.Tracks.Add(new TrackDto
                    {
                        Id = track.Id,
                        Name = track.Name,
                        DiscNumber = track.DiscNumber,
                        DurationMs = track.DurationMs,
                        Explicit = track.Explicit,
                        TrackNumber = track.TrackNumber
                    });
                }
                return Ok(dto);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }
    }
}
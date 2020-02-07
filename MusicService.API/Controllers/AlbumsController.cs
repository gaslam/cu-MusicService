using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.DTO;
using System;
using System.Linq;
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
            var albums = await _musicServiceContext.Albums
                .Include(a => a.Artist)
                .Select(a => new AlbumWithArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    ArtistId = a.Artist.Id,
                    Artist = a.Artist.Name
                })
                .ToListAsync();
            return Ok(albums);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByIdAsync(string id)
        {
            var album = await _musicServiceContext.Albums.Include(a => a.Artist).SingleOrDefaultAsync(a => a.Id == Guid.Parse(id));

            if (album != null)
            {
                var dto = new AlbumWithArtistDto
                {
                    Id = album.Id,
                    Name = album.Name,
                    ArtistId = album.Artist.Id,
                    Artist = album.Artist.Name
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
            var album = await _musicServiceContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .SingleOrDefaultAsync(a => a.Id.ToString() == id);

            if (album != null)
            {
                var dto = new AlbumDetailDto
                {
                    Id = album.Id,
                    Name = album.Name,
                    ArtistId = album.Artist.Id,
                    Artist = album.Artist.Name,
                    Tracks = album.Tracks.Select(t => new TrackDto
                    {
                        Id = t.Id,
                        Name = t.Name,
                        DiscNumber = t.DiscNumber,
                        DurationMs = t.DurationMs,
                        Explicit = t.Explicit,
                        TrackNumber = t.TrackNumber
                    }).ToList()
                };

                return Ok(dto);
            }
            else
            {
                return NotFound($"Album with {id} was not found!");
            }
        }
    }
}
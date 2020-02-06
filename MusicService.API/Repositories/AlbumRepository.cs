using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.DTO;
using MusicService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Repositories
{
    public class AlbumRepository
    {
        private readonly MusicServiceContext db;

        public AlbumRepository(MusicServiceContext context)
        {
            db = context;
        }

        // return a list of albums from database table album
        public async Task<List<Album>> ListAsync()
        {
            return await db.Albums.ToListAsync();
        }

        // return a list of albums as a list of AlbumDto's
        public async Task<List<AlbumWithArtistDto>> ListDtoAsync()
        {
            return await db.Albums.Include(a => a.Artist).Select(a => new AlbumWithArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                ArtistId = a.Artist.Id,
                Artist = a.Artist.Name
            }).ToListAsync();
        }

        public async Task<Album> GetByIdAsync(string id)
        {
            return await db.Albums.FindAsync(Guid.Parse(id));
        }

        public async Task<AlbumWithArtistDto> GetDtoByIdAsync(string id)
        {
            var model = await db.Albums.Include(a => a.Artist).FirstOrDefaultAsync(a => a.Id == Guid.Parse(id));

            if (model == null)
            {
                return null;
            }

            return new AlbumWithArtistDto
            {
                Id = model.Id,
                Name = model.Name,
                ArtistId = model.Artist.Id,
                Artist = model.Artist.Name
            };
        }

        public async Task<AlbumDetailDto> GetDetailDtoById(string id)
        {
            var model = await db.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.Id.ToString() == id);

            if (model == null)
            {
                return null;
            }

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
            return dto;
        }
    }
}

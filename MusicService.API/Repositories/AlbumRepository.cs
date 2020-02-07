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
        private readonly MusicServiceContext _musicServiceContext;

        public AlbumRepository(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }

        // return a list of albums from database table album
        public async Task<List<Album>> ListAsync()
        {
            return await _musicServiceContext.Albums.ToListAsync();
        }

        // return a list of albums as a list of AlbumDto's
        public async Task<List<AlbumWithArtistDto>> ListDtoAsync()
        {
            return await _musicServiceContext.Albums.Include(a => a.Artist).Select(a => new AlbumWithArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                ArtistId = a.Artist.Id,
                Artist = a.Artist.Name
            }).ToListAsync();
        }

        public async Task<Album> GetByIdAsync(string id)
        {
            return await _musicServiceContext.Albums.FindAsync(Guid.Parse(id));
        }

        public async Task<AlbumWithArtistDto> GetDtoByIdAsync(string id)
        {
            var album = await _musicServiceContext.Albums.Include(a => a.Artist).SingleOrDefaultAsync(a => a.Id == Guid.Parse(id));

            if (album == null)
            {
                return null;
            }

            return new AlbumWithArtistDto
            {
                Id = album.Id,
                Name = album.Name,
                ArtistId = album.Artist.Id,
                Artist = album.Artist.Name
            };
        }

        public async Task<AlbumDetailDto> GetDetailDtoById(string id)
        {
            var album = await _musicServiceContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .SingleOrDefaultAsync(a => a.Id.ToString() == id);

            if (album == null)
            {
                return null;
            }

            var dto = new AlbumDetailDto
            {
                Id = album.Id,
                Name = album.Name,
                ArtistId = album.Artist.Id,
                Artist = album.Artist.Name,
                Tracks = album.Tracks.Select(t => new TrackDto
                {
                    Id = t.Id,
                    TrackNumber = t.TrackNumber,
                    Explicit = t.Explicit,
                    DiscNumber = t.DiscNumber,
                    DurationMs = t.DurationMs,
                    Name = t.Name
                }).ToList()
            };

            return dto;
        }
    }
}

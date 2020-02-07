using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicService.API.Repositories
{
    public class GenreRepository
    {
        private readonly MusicServiceContext _musicServiceContext;

        public GenreRepository(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }

        // return a list of genres from database table genre
        public async Task<List<Genre>> ListAsync()
        {
            return await _musicServiceContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(string id)
        {
            return await _musicServiceContext.Genres.FindAsync(Guid.Parse(id));
        }

        public async Task<Genre> Add(Genre genre)
        {
            _musicServiceContext.Genres.Add(genre);
            await _musicServiceContext.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Update(Genre genre)
        {
            try
            {
                _musicServiceContext.Entry(genre).State = EntityState.Modified;
                await _musicServiceContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(genre.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return genre;
        }

        public async Task<Genre> Delete(string id)
        {
            var genre = await GetByIdAsync(id);
            if (genre == null)
            {
                return null;
            }

            _musicServiceContext.Genres.Remove(genre);
            await _musicServiceContext.SaveChangesAsync();
            return genre;
        }

        private bool GenreExists(Guid id)
        {
            return _musicServiceContext.Genres.Any(g => g.Id == id);
        }

    }
}

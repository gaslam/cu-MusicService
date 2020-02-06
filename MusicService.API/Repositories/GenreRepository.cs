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
        private readonly MusicServiceContext db;

        public GenreRepository(MusicServiceContext context)
        {
            db = context;
        }

        // return a list of genres from database table genre
        public async Task<List<Genre>> ListAsync()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(string id)
        {
            return await db.Genres.FindAsync(Guid.Parse(id));
        }

        public async Task<Genre> Add(Genre genre)
        {
            db.Genres.Add(genre);
            await db.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Update(Genre genre)
        {
            try
            {
                db.Entry(genre).State = EntityState.Modified;
                await db.SaveChangesAsync();
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

            db.Genres.Remove(genre);
            await db.SaveChangesAsync();
            return genre;
        }

        private bool GenreExists(Guid id)
        {
            return db.Genres.Any(g => g.Id == id);
        }

    }
}

using MusicService.API.Data;
using MusicService.API.Repositories.Base;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(MusicServiceContext context) : base(context)
        {
        }
    }
}

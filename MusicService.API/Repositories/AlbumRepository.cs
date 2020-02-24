using MusicService.API.Data;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class AlbumRepository : Repository<Album>, IRepository<Album>
    {
        public AlbumRepository(MusicServiceContext context) : base(context)
        {
        }
    }
}

using MusicService.API.Data;
using MusicService.API.Repositories.Base;
using MusicService.Domain.Models;

namespace MusicService.API.Repositories
{
    public class AlbumRepository : Repository<Album>
    {
        public AlbumRepository(MusicServiceContext context) : base(context)
        {
        }
    }
}

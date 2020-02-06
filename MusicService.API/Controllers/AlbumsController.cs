using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerCrudBase<Album, AlbumRepository>
    {

        public AlbumsController(AlbumRepository albumRepository) : base(albumRepository)
        {
        }
    }
}
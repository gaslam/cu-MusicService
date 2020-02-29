using Microsoft.AspNetCore.Mvc;
using MusicService.API.Controllers.Base;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerCrudBase<Album, IRepository<Album>>
    {

        public AlbumsController(IRepository<Album> albumRepository) : base(albumRepository)
        {
        }
    }
}
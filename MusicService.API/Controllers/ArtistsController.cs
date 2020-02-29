using Microsoft.AspNetCore.Mvc;
using MusicService.API.Controllers.Base;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerCrudBase<Artist, IRepository<Artist>>
    {

        public ArtistsController(IRepository<Artist> artistRepository) : base(artistRepository)
        {
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MusicService.API.Repositories;
using MusicService.Domain.Models;

namespace MusicService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerCrudBase<Artist, ArtistRepository>
    {

        public ArtistsController(ArtistRepository artistRepository) : base(artistRepository)
        {
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistApi.Backend.DTOs;
using PlaylistApi.Backend.Models;
using System.Threading.Tasks;

namespace PlaylistApi.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // In Memory Database is used for caching
        private readonly PlaylistDataContext _dataContext;

        public UsersController(PlaylistDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}/stats", Name = "GetStatsByUserId")]
        public async Task<ActionResult<UserDto>> GetStatsByUserId(long id)
        {
            if (await _dataContext.Playlists.AnyAsync())
            {
                return new UserModel
                {
                    Id = id,
                    Playlists = await _dataContext.Playlists.Include(x=>x.Tracks).ToListAsync()
                }.GetDto();
            }

            return NotFound("User has no playlist");

        }
    }
}
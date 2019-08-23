using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistApi.Backend.DTOs;
using PlaylistApi.Backend.Models;
using PlaylistApi.Backend.Services;
using System;
using System.Threading.Tasks;

namespace PlaylistApi.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        // In Memory Database is used for caching
        private readonly PlaylistDataContext _dataContext;
        private readonly IMusicInformationService _spotifyService;

        public PlaylistsController(PlaylistDataContext dataContext, IMusicInformationService spotifyService)
        {
            _dataContext = dataContext;
            _spotifyService = spotifyService;
        }

        /// <summary>
        /// Returns playlist analysis data by Spotify playlist ID
        /// </summary>
        /// <param name="id">The Spotify playlist ID. Example: 37i9dQZF1DX3WvGXE8FqYX</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPlaylist")]
        public async Task<ActionResult<PlaylistDto>> GetById(string id)
        {
            try
            {            
                // If playlist exists in in-memory db provider (cache),  don't call Spotify. Then return the stored version from cache
                var existingPlaylist = await _dataContext.Playlists.Include(x=>x.Tracks).FirstOrDefaultAsync(x => x.ExternalId == id);
                if (existingPlaylist != null)
                    return existingPlaylist.GetDto();

                // Call Spotify service

                var newPlaylist = await _spotifyService.GetPlaylist(id);
                // save to in-memory db provider for caching
                _dataContext.Playlists.Add(newPlaylist);
                await _dataContext.SaveChangesAsync();

                return newPlaylist.GetDto();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
using Microsoft.Extensions.Configuration;
using PlaylistApi.Backend.Models;
using SpotifyApi.NetCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaylistApi.Backend.Services
{
    public class SpotifyService : IMusicInformationService
    {
        private readonly IConfiguration _configuration;

        public SpotifyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PlaylistModel> GetPlaylist(string id)
        {
            try
            {
                var http = new HttpClient();
                var accounts = new AccountsService(http, _configuration);
                var playlistsApi = new PlaylistsApi(http, accounts);
                var tracksApi = new TracksApi(http, accounts);
                int limit = 100;
                var playlistTracks = await playlistsApi.GetTracks(id, limit: limit);
                int offset = 0;
                int j = 0;
                // Go through all pages since Spotify only returns 100 tracks at once for a playlist
                var trackModels = new List<TrackModel>();
                while (playlistTracks.Items.Any())
                {
                    var tracksWithAudioFeatures = await tracksApi.GetTracksAudioFeatures(playlistTracks.Items.Select(x => x.Track.Id).ToArray());
                    trackModels.AddRange(tracksWithAudioFeatures.Select(x => new TrackModel
                    {
                        ExternalId = x.Id,
                        Danceability = x.Danceability,
                        Energy = x.Energy,
                        Valence = x.Valence,
                        Popularity = playlistTracks.Items.FirstOrDefault(y => y.Track.Id == x.Id)?.Track.Popularity ?? 0,
                        Artists = playlistTracks.Items.FirstOrDefault(y => y.Track.Id == x.Id)?.Track.Artists.FirstOrDefault()?.Name ?? string.Empty,
                        Name = playlistTracks.Items.FirstOrDefault(y => y.Track.Id == x.Id)?.Track.Name ?? string.Empty,
                        PreviewUrl = playlistTracks.Items.FirstOrDefault(y => y.Track.Id == x.Id)?.Track.PreviewUrl ?? string.Empty,
                    }));
                    offset += limit;
                    playlistTracks = await playlistsApi.GetTracks(id, limit: limit, offset: offset);
                }

                var newPlaylist = new PlaylistModel(id, trackModels);
                return newPlaylist;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                throw new Exception("Error getting playlist from Spotify");
            }
        }
    }
}

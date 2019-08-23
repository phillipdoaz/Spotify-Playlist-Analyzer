using PlaylistApi.Backend.Models;
using System.Threading.Tasks;

namespace PlaylistApi.Backend.Services
{
    public interface IMusicInformationService
    {
        Task<PlaylistModel> GetPlaylist(string id);
    }
}
using PlaylistApi.Backend.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistApi.Backend.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public List<PlaylistModel> Playlists { get; set; }

        public UserDto GetDto()
        {
            return new UserDto
            {
                UserId = Id,
                Stats = Playlists.Select(x => x.GetDto()).ToList()
            };
        }
    }
}

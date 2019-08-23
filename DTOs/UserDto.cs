using System.Collections.Generic;

namespace PlaylistApi.Backend.DTOs
{
    public class UserDto
    {
        public long UserId { get; set; }

        public List<PlaylistDto> Stats { get; set; }
    }
}

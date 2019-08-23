using Microsoft.EntityFrameworkCore;

namespace PlaylistApi.Backend.Models
{
    public class PlaylistDataContext : DbContext
    {
        public PlaylistDataContext(DbContextOptions<PlaylistDataContext> options)
            : base(options)
        {
        }

        public DbSet<PlaylistModel> Playlists { get; set; }

        public DbSet<TrackModel> PlaylistTracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:phillipspotify.database.windows.net,1433;Initial Catalog=phillipspotify;Persist Security Info=False;User ID=rootuser;Password=l3SaQMq3NY3i4cWa5ejuqYPffvyp9pweVPM683gjlDggMUXT;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}

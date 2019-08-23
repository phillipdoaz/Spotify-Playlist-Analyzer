using PlaylistApi.Backend.DTOs;

namespace PlaylistApi.Backend.Models
{
    public class TrackModel
    {
        public long Id { get; set; }

        public string ExternalId { get; set; }

        public double Danceability { get; set; }

        public double Energy { get; set; }

        public double Valence { get; set; }

        public int Popularity { get; set; }

        public string Artists { get; set; }

        public string Name { get; set; }

        public string PreviewUrl { get; set; }

        public TrackDto GetDto()
        {
            return new TrackDto
            {
                TrackId = ExternalId,
                Artists = Artists,
                Name = Name,
                PreviewUrl = PreviewUrl
            };
        }
    }
}
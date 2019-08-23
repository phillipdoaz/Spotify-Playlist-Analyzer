namespace PlaylistApi.Backend.DTOs
{
    public class PlaylistDto
    {
        public string PlaylistId { get; set; }

        public AudioFeatureDto Danceability { get; set; }

        public AudioFeatureDto Energy { get; set; }

        public AudioFeatureDto Valence { get; set; }

        public double Overall { get; set; }

        public TrackDto HighestRatedTrack { get; set; }

        public TrackDto LowestRatedTrack { get; set; }
    }
}
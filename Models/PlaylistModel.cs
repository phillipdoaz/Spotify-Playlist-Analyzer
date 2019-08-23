using System.Collections.Generic;
using System.Linq;
using PlaylistApi.Backend.DTOs;

namespace PlaylistApi.Backend.Models
{
    public class PlaylistModel
    {
        public long Id { get; set; }

        public string ExternalId { get; set; }

        public List<TrackModel> Tracks { set; get;  }

        public double DanceabilityMin { get; set; }

        public double DanceabilityMax { get; set; }

        public double EnergyMin { get; set; }

        public double EnergyMax { get; set; }

        public double ValenceMin { get; set; }

        public double ValenceMax { get; set; }

        public double Overall { get; set; }

        public string HighestRatedTrackId { get; set; }

        public string LowestRatedTrackId { get; set; }

        public PlaylistModel()
        {
            Tracks = new List<TrackModel>();
        }

        public PlaylistModel(string externalId, List<TrackModel> tracks)
        {
            ExternalId = externalId;
            Tracks = tracks;
            //calculate stats but only once in constructor when the object is first created
            DanceabilityMin = Tracks.Min(x => x.Danceability);
            DanceabilityMax = Tracks.Max(x => x.Danceability);
            EnergyMin = Tracks.Min(x => x.Energy);
            EnergyMax = Tracks.Max(x => x.Energy);
            ValenceMin = Tracks.Min(x => x.Valence);
            ValenceMax = Tracks.Max(x => x.Valence);
            Overall = (Tracks.Average(x => x.Danceability) + Tracks.Average(x => x.Energy) + Tracks.Average(x => x.Valence) / 3);
            HighestRatedTrackId = Tracks.FirstOrDefault(x => x.Popularity == Tracks.Max(y => y.Popularity))?.ExternalId;
            LowestRatedTrackId = Tracks.FirstOrDefault(x => x.Popularity == Tracks.Min(y => y.Popularity))?.ExternalId;
        }

        public PlaylistDto GetDto()
        { 
            return new PlaylistDto
            {
                PlaylistId = ExternalId,
                Danceability = new AudioFeatureDto
                {
                    Min = DanceabilityMin,
                    Max = DanceabilityMax
                },
                Energy = new AudioFeatureDto
                {
                    Min = EnergyMin,
                    Max = EnergyMax
                },
                Valence = new AudioFeatureDto
                {
                    Min = ValenceMin,
                    Max = ValenceMax
                },
                Overall = Overall,
                HighestRatedTrack = Tracks.FirstOrDefault(x=>x.ExternalId == HighestRatedTrackId)?.GetDto(),
                LowestRatedTrack = Tracks.FirstOrDefault(x => x.ExternalId == LowestRatedTrackId)?.GetDto()
            };
            
        }
    }
}
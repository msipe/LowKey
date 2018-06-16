using LowKey.Core.Source.Management.Mappings;

namespace LowKey.Core.Source.Management {
  public class LowInterestArtistHandler {
    public CandidateArtists LookForCandidateArtists() {
      return new CandidateArtists { Artists = new[] { new Artist() } };
    }
  }
}

using LowKey.Core.Source.Management.Mappings;

namespace LowKey.Core.Source.Management {
  public class SimilarArtists {
    public SimilarArtists(Artist[] artists) {
      Artist = artists;
    }
    public Artist[] Artist { get; set; }
  }
}
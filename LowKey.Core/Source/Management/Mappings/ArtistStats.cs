namespace LowKey.Core.Source.Management.Mappings {
  public class ArtistStats {
    public ArtistStats(int listeners, int playcount) {
      Listeners = listeners;
      Playcount = playcount;
    }
    public int Listeners {get; set;}
    public int Playcount {get; set;}
  }
}
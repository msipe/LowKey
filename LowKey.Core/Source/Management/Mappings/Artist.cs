namespace LowKey.Core.Source.Management.Mappings {
  public class Artist {
    public Artist(string name) {
      Name = name;
    }
    public string Name {get; set;}
    public ArtistStats Stats {get; set;}
  }
}
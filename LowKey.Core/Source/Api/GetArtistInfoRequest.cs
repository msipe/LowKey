namespace LowKey.Core.Source.Api {
  public class GetArtistInfoRequest {
    public GetArtistInfoRequest(string artistName, string key) {
      mArtistName = artistName;
      mKey = key;
    }

    public string GetString() {
      return string.Format("http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist={0}&api_key={1}&format=json", mArtistName, mKey);
    }

    private string mArtistName;
    private string mKey;
  }
}

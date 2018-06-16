using LowKey.Core.Source.Api.Constants;

namespace LowKey.Core.Source.Api {
  public class GetArtistInfoRequest {
    public GetArtistInfoRequest(string artistName, string key) {
      mArtistName = artistName;
      mKey = key;
    }

    public string GetString() {
      return string.Format("{0}?method=artist.getinfo&artist={1}&api_key={2}&format=json", ApiConstants.LastFmBaseUrl, mArtistName, mKey);
    }

    private string mArtistName;
    private string mKey;
  }
}

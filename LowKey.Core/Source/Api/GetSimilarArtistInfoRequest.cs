using LowKey.Core.Source.Api.Constants;

namespace LowKey.Core.Source.Api {
  public class GetSimilarArtistsRequest:IRequest {
    public GetSimilarArtistsRequest(string artistName, string key) {
      mArtistName = artistName;
      mKey = key;
    }

    public string GetString() {
      return string.Format("{0}?method=artist.getsimilar&artist={1}&api_key={2}&limit=50&format=json", ApiConstants.LastFmBaseUrl, ParseArtistName(mArtistName), mKey);
    }

    private string ParseArtistName(string incomingName) {
      return incomingName.Replace(' ', '+');
    }

    private string mArtistName;
    private string mKey;
  }
}

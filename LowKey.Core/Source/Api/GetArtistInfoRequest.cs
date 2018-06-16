namespace LowKey.Core.Source.Api {
  public class GetArtistInfoRequest {
    public GetArtistInfoRequest(string artistName) {
      mArtistName = artistName;
    }

    public string GetString() {
      return mArtistName;
    }

    private string mArtistName;
  }
}

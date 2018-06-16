using LowKey.Core.Source.Api;
using Newtonsoft.Json;

namespace LowKey.Core.Source.Management {
  public class Runner {
    public Runner(IRequestHandler requestHandler) {
      mRequestHandler = requestHandler;
    }

    public SimilarArtists InitSimilarArtistsRequest(IRequest request) {
      var requestContent = mRequestHandler.ReadRequest(mRequestHandler.SendRequest(request));
      return Deserialize<SimilarArtists>(requestContent);
    }

    private T Deserialize<T>(string json) {
      return JsonConvert.DeserializeObject<T>(json);
    }

    private IRequestHandler mRequestHandler;
    
  }
}

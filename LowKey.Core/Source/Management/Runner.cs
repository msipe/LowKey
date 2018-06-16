using LowKey.Core.Source.Api;
using Newtonsoft.Json;

namespace LowKey.Core.Source.Management {
  public class Runner {
    public Runner(IRequestHandler requestHandler) {
      mRequestHandler = requestHandler;
    }

    public SimilarArtists InitSimilarArtistsRequest(IRequest request) {
      return JsonConvert.DeserializeObject<SimilarArtists>(mRequestHandler.SendRequest(request).ToString());
    }

    private IRequestHandler mRequestHandler;
    
  }
}

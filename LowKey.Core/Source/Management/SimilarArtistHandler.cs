using LowKey.Core.Source.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using LowKey.Core.Source.Management.Mappings;

namespace LowKey.Core.Source.Management {
  public class SimilarArtistHandler {
    public SimilarArtistHandler(IRequestHandler requestHandler) {
      mRequestHandler = requestHandler;
    }

    public SimilarArtistWrapper InitSimilarArtistsRequest(IRequest request) {
      var requestContent = mRequestHandler.ReadRequest(mRequestHandler.SendRequest(request));
      return Deserialize<SimilarArtistWrapper>(requestContent);
    }

    private T Deserialize<T>(string json) {
      return JsonConvert.DeserializeObject<T>(json);
    }

    private IRequestHandler mRequestHandler;
    private MemoryTraceWriter tw;
  }
}

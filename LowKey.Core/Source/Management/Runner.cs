using LowKey.Core.Source.Api;

namespace LowKey.Core.Source.Management {
  public class Runner {
    public Runner(IHttpClient httpClient) {
      mRequestHandler = new RequestHandler(httpClient);
    }

    private RequestHandler mRequestHandler;
  }
}

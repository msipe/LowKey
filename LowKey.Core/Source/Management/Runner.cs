using LowKey.Core.Source.Api;

namespace LowKey.Core.Source.Management {
  public class Runner {
    public Runner(IRequestHandler requestHandler) {
      mRequestHandler = requestHandler;
    }

    private IRequestHandler mRequestHandler;
  }
}

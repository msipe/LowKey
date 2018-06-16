using System.Net.Http;


namespace LowKey.Core.Source.Api {
  public interface IRequestHandler {
    HttpResponseMessage SendRequest(IRequest request);
    string ReadRequest(HttpResponseMessage message);
  }
}

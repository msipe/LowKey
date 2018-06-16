using System.Net.Http;

namespace LowKey.Core.Source.Api {
  public interface IHttpClient {
    HttpResponseMessage GetAsync(string requestUri);
  }
}

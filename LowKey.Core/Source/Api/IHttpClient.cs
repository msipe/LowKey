using System.Net.Http;
using System.Threading.Tasks;

namespace LowKey.Core.Source.Api {
  public interface IHttpClient {
    HttpResponseMessage GetAsync(string requestUri);
    string ReadAsync(HttpResponseMessage message);
  }
}

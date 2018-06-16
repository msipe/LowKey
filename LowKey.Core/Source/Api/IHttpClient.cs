using System.Threading.Tasks;

namespace LowKey.Core.Source.Api {
  public interface IHttpClient {
    Task<System.Net.Http.HttpResponseMessage> GetAsync(string requestUri);
  }
}

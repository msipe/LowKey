using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LowKey.Core.Source.Api {
  public class HttpClientAdapter:IHttpClient {
    public HttpClientAdapter() {
      mHttpClient = new HttpClient();
    }

    public Task<System.Net.Http.HttpResponseMessage> GetAsync(string requestUri) {
      return mHttpClient.GetAsync(requestUri);
    }

    private HttpClient mHttpClient;
  }
}

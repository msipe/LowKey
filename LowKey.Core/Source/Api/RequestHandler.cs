using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LowKey.Core.Source.Api {
  public class RequestHandler:IRequestHandler {
    public RequestHandler(IHttpClient httpClient) {
      mHttpClient = httpClient;
    }
    public HttpResponseMessage SendRequest(IRequest request) {
      return mHttpClient.GetAsync(request.GetString());
    }

    private IHttpClient mHttpClient;
  }
}

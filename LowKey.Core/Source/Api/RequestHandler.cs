using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowKey.Core.Source.Api {
  public class RequestHandler {
    public RequestHandler(IHttpClient httpClient) {
      mHttpClient = httpClient;
    }
    public void SendRequest(IRequest request) {
      mHttpClient.GetAsync(request.GetString());
    }

    private IHttpClient mHttpClient;
  }
}

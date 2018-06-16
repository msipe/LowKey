using System;
using LowKey.Core.Source.Api;
using Newtonsoft.Json;
using LowKey.Core.Source.Management;

namespace LowKey {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("hello there");
      Run();
    }

    static void Run() {
      var httpClient = new HttpClientAdapter();
      var handler = new RequestHandler(httpClient);
      var runner = new SimilarArtistHandler(handler);
      var request = new GetSimilarArtistsRequest("metallica", "key");
      Console.WriteLine(runner.InitSimilarArtistsRequest(request).SimilarArtists.Artist[0].Name);
      Console.WriteLine(runner.InitSimilarArtistsRequest(request).SimilarArtists.Artist[1].Name);
      Console.WriteLine(runner.InitSimilarArtistsRequest(request).SimilarArtists.Artist[2].Name);
      //var response = handler.SendRequest(request);
      //var result = handler.ReadRequest(response);

      //var json = JsonConvert.DeserializeObject(result);
      //Console.WriteLine(json);
    }
  }
}

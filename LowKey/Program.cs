using System;
using LowKey.Core.Source.Api;
using Newtonsoft.Json;
using LowKey.Core.Source.Management;
using LowKey.Core.Source.Display;

namespace LowKey {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("hello there");
      Run();
    }

    static void Run() {
      var key = "d603efbd297006bc2578f39e32f507dd";
      var httpClient = new HttpClientAdapter();
      var handler = new RequestHandler(httpClient);
      var similarArtistHandler = new SimilarArtistHandler(handler);
      var request = new GetSimilarArtistsRequest("In Flames", key);
      var results = similarArtistHandler.InitSimilarArtistsRequest(request);
      var lowInterestHandler = new LowInterestArtistHandler(handler, key);
      var artistData = lowInterestHandler.PullArtistData(results.SimilarArtists);
      var lowInterest = lowInterestHandler.SelectLowInterestArtists(artistData, 30000);
      var manager = new OutputManager();
      Console.WriteLine(manager.Display(lowInterest));
    }
  }
}

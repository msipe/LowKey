using System;
using LowKey.Core.Source.Api;
using Newtonsoft.Json;

namespace LowKey {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("hello there");
      Run();
    }

    static async void Run() {
      var httpClient = new HttpClientAdapter();
      var handler = new RequestHandler(httpClient);
      var request = new GetArtistInfoRequest("metallica", "key");
      var response = handler.SendRequest(request);
      var text = await response.Content.ReadAsStringAsync();
      var json = JsonConvert.DeserializeObject(text);
      Console.WriteLine(json);
    }
  }
}

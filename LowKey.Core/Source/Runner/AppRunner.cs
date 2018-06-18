using LowKey.Core.Source.Api;
using LowKey.Core.Source.Display;
using LowKey.Core.Source.Management;
using LowKey.Core.Source.Management.Mappings;
using System;

namespace LowKey.Core.Source.Runner {
  public class AppRunner {
    public AppRunner(Config config) {
      mConfig = config;
      mRequestHandler = new RequestHandler(new HttpClientAdapter());
    }

    public string Init() {
      var similarArtists = GetSimilarArtists();
      var lowInterestArtists = GetLowInterestArtists(similarArtists.SimilarArtists);
      return Display(lowInterestArtists);
    }

    private SimilarArtistsWrapper GetSimilarArtists() {
      var similarArtistHandler = new SimilarArtistHandler(mRequestHandler);
      var request = new GetSimilarArtistsRequest(mConfig.Artist, mConfig.Key);
      return similarArtistHandler.InitSimilarArtistsRequest(request);
    }

    private  Artist[] GetLowInterestArtists(SimilarArtists similarArtists) {
      var lowInterestHandler = new LowInterestArtistHandler(mRequestHandler, mConfig.Key);
      var artistData = lowInterestHandler.PullArtistData(similarArtists);
      return lowInterestHandler.SelectLowInterestArtists(artistData, mConfig.Cutoff);
    }

    private string Display(Artist[] lowInterestArtists) {
      var manager = new OutputManager();
      var output = manager.Display(lowInterestArtists);
      Console.WriteLine(output);
      return output;
    }



    private Config mConfig;
    private IRequestHandler mRequestHandler;
  }
}

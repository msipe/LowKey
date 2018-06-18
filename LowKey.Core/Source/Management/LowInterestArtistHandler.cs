using LowKey.Core.Source.Api;
using LowKey.Core.Source.Management.Mappings;
using LowKey.Core.Source.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LowKey.Core.Source.Management {
  public class LowInterestArtistHandler {
    public LowInterestArtistHandler(IRequestHandler requestHandler, string key) {
      mRequestHandler = requestHandler;
      mKey = key;
    }
    public Artist[] PullArtistData(SimilarArtists artistPool) {
      var candidates = new List<ArtistWrapper>();
      foreach(var x in artistPool.Artist) {
        var text = mRequestHandler.ReadRequest(mRequestHandler.SendRequest(new GetArtistInfoRequest(x.Name, mKey)));
        candidates.Add(JsonParser.Deserialize<ArtistWrapper>(text));
      }
      return RemoveArtistWrapper(candidates.ToArray());
    }

    public Artist[] SelectLowInterestArtists(Artist[] artists, int cutoff) {
      var results = new List<Artist>();
      foreach(var x in artists) {
        if (x.Stats.Listeners < cutoff) {
          results.Add(x);
        }
      }

      return results.ToArray();
    }

    private Artist[] RemoveArtistWrapper(ArtistWrapper[] wrapper) {
      var result = new List<Artist>();

      Array.ForEach(wrapper, w => result.Add(w.Artist));

      return result.ToArray();
    }

    private IRequestHandler mRequestHandler;
    private string mKey;
    
  }
}

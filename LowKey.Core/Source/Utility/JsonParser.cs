using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowKey.Core.Source.Utility {
  public static class JsonParser {
    public static T Deserialize<T>(string json) {
      return JsonConvert.DeserializeObject<T>(json);
    }

    public static T Deserialize<T>(string json, bool debug) {
      var tw = new MemoryTraceWriter();
      if (debug) {
       var result = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { TraceWriter = tw });
        Console.WriteLine(tw);
        return result;
      }
      return JsonConvert.DeserializeObject<T>(json);
    }
  }
}

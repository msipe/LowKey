using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowKey.Core.Source.Runner {
  public class Config {
    public Config(string artist, int cutoff, string key) {
      Artist = artist;
      Cutoff = cutoff;
      Key = key;
    }
    public string Artist { get; private set; }
    public int Cutoff { get; private set; }
    public string Key { get; private set; }
  }
}

using LowKey.Core.Source.Management.Mappings;
using System;

namespace LowKey.Core.Source.Display {
  public class OutputManager {
    public string Display(Artist[] artists) {
      if (artists.Length == 0) {
        return "No artists found";
      }
      return Header + FormatArtists(artists);
    }

    private string FormatArtists(Artist[] artists) {
      string lines = "";
      Array.ForEach(artists, a => lines = lines + FormatLine(a));
      return lines;
    }

    public string FormatLine(Artist artist) {
      return string.Format("{1} - {2}{0}", Environment.NewLine, artist.Name, artist.Stats.Listeners);
    }


    private string Header = "Results" + Environment.NewLine;
  }
}

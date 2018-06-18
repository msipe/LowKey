using LowKey.Core.Source.Display;
using LowKey.Core.Source.Management.Mappings;
using NUnit.Framework;
using System;

namespace LowKey.UnitTests.Source.Display {
  [TestFixture]
  public class OutputManagerTest {
    [Test]
    public void TestOutputmanagerDisplaysCorrectValuesWithSingleArtist() {
      var manager = new OutputManager();
      var artists = new[] { new Artist("artist 1") { Stats = new ArtistStats(100, 12) }};
      var result = manager.Display(artists);

      Assert.That(result, Is.EqualTo(string.Format("Results{0}{1}{0}", Environment.NewLine, "artist 1 - 100")));
    }

    [Test]
    public void TestOutputmanagerDisplaysCorrectValuesWithMultipleArtists() {
      var manager = new OutputManager();
      var artists = new[] {
        new Artist("artist 1") { Stats = new ArtistStats(100, 12) },
        new Artist("artist 2") { Stats = new ArtistStats(123, 2) },
        new Artist("artist 3") { Stats = new ArtistStats(41, 122) }
      };

      var result = manager.Display(artists);
      Assert.That(result, Is.EqualTo(string.Format("Results{0}{1}{0}{2}{0}{3}{0}", Environment.NewLine, "artist 1 - 100", "artist 2 - 123", "artist 3 - 41")));
    }

    [Test]
    public void TestOutputmanagerDisplaysCorrectValuesWithZeroArtists() {
      var manager = new OutputManager();
      var artists = new Artist[] {};

      var result = manager.Display(artists);
      Assert.That(result, Is.EqualTo("No artists found"));
    }
  }
}

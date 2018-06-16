using NUnit.Framework;
using LowKey.Core.Source.Api;

namespace LowKey.UnitTests.Source.Api {
  [TestFixture]
  class GetArtistInfoRequestTest {
    [Test]
    public void TestGetArtistInfoRequestPutsCorrectStringTogether() {
      var request = new GetArtistInfoRequest("testArtist", "key2");
      Assert.That(request.GetString(), Is.EqualTo("http://ws.audioscrobbler.com/2.0/?method=artist.getinfo&artist=testArtist&api_key=key2&format=json"));
      
    }
  }
}

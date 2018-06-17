using NUnit.Framework;
using LowKey.Core.Source.Api;

namespace LowKey.UnitTests.Source.Api {
  [TestFixture]
  class GetSimilarArtistsRequestTest {
    [Test]
    public void TestGetSimilarArtistsRequestPutsStringTogetherCorrectly() {
      var request = new GetSimilarArtistsRequest("testArtist", "key2");
      Assert.That(request.GetString(), Is.EqualTo("http://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist=testArtist&api_key=key2&limit=50&format=json"));
    }

    [Test]
    public void TestGetArtistInfoRequestHandlesSpaces() {
      var request = new GetSimilarArtistsRequest("test Artist", "key2");
      Assert.That(request.GetString(), Is.EqualTo("http://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist=test+Artist&api_key=key2&limit=50&format=json"));
    }
  }
}

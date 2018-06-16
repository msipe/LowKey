using NUnit.Framework;
using LowKey.Core.Source.Api;

namespace LowKey.UnitTests.Source.Api {
  [TestFixture]
  class GetArtistInfoRequestTest {
    [Test]
    public void TestGetArtistInfoRequestPutsCorrectStringTogether() {
      var request = new GetArtistInfoRequest("test artist");
      Assert.That(request.GetString(), Is.EqualTo("test artist"));
      
    }
  }
}

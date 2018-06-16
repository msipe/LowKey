using LowKey.Core.Source.Api;
using NUnit.Framework;

namespace LowKey.UnitTests.Source.Api.Execution {
  [TestFixture]
  class RequestHandlerTest {
    [Test]
    public void TestSendRequestUsesTheCorrectString() {
      var request = new GetSimilarArtistsRequest("test", "key");
      var handler = new RequestHandler();
      handler.SendRequest(request);
    }
  }
}

using LowKey.Core.Source.Api;
using NUnit.Framework;
using Moq;
using System.Net.Http;

namespace LowKey.UnitTests.Source.Api.Execution {
  [TestFixture]
  class RequestHandlerTest {
    [Test]
    public void TestSendRequestUsesTheCorrectString() {
      var request = new GetSimilarArtistsRequest("test", "key");
      var handler = new RequestHandler();
      handler.SendRequest(request);
    }

    [SetUp]
    public void DoSetup() {
      mHttpClient = new Mock<HttpClient>();
    }

    private IMock<HttpClient> mHttpClient;
  }
}

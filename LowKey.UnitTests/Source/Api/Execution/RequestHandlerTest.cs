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
      var handler = new RequestHandler(mHttpClient.Object);
      mHttpClient.Setup(s => s.GetAsync(request.GetString())).Returns(new HttpResponseMessage()).Verifiable();
      handler.SendRequest(request);
      mHttpClient.Verify();
    }

    [SetUp]
    public void DoSetup() {
      mHttpClient = new Mock<IHttpClient>(MockBehavior.Strict);
    }

    private Mock<IHttpClient> mHttpClient;
  }
}

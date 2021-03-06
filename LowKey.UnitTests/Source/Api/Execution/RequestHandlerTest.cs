﻿using LowKey.Core.Source.Api;
using NUnit.Framework;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LowKey.UnitTests.Source.Api.Execution {
  [TestFixture]
  class RequestHandlerTest {
    [Test]
    public void TestSendRequestUsesTheCorrectString() {
      var request = new GetSimilarArtistsRequest("test", "key");
      mHttpClient
        .Setup(s => s.GetAsync(request.GetString()))
        .Returns(new HttpResponseMessage())
        .Verifiable();

      mHandler.SendRequest(request);
      mHttpClient.Verify();
    }

    [Test]
    public void TestReadRequestReturnsCorrectValues() {
      var message = new HttpResponseMessage();
      mHttpClient
        .Setup(s => s.ReadAsync(message))
        .Returns("babble")
        .Verifiable();

      Assert.That(mHandler.ReadRequest(message), Is.EqualTo("babble"));
      mHttpClient.Verify();
    }

    [SetUp]
    public void DoSetup() {
      mHttpClient = new Mock<IHttpClient>(MockBehavior.Strict);
      mHandler = new RequestHandler(mHttpClient.Object);
    }

    private Mock<IHttpClient> mHttpClient;
    private RequestHandler mHandler;
  }
}

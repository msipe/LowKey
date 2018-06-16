﻿using LowKey.Core.Source.Api;
using LowKey.Core.Source.Management;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;

namespace LowKey.UnitTests.Source.Management {
  [TestFixture]
  public class RunnerTest {
    [Test]
    public void TestRunnerInitsSimilarArtistRequestAndReturnsParsedObject() {
      var request = new GetSimilarArtistsRequest("artist", "key3");
      var message = new HttpResponseMessage();
      mRequestHandler
        .Setup(s => s.SendRequest(request))
        .Returns(message)
        .Verifiable();

      mRequestHandler
        .Setup(r => r.ReadRequest(message))
        .Returns("{'Artists':[{'Name':'wow'}]}")
        .Verifiable();
      
      var result = mRunner.InitSimilarArtistsRequest(request);

      Assert.That(result.Artists.Length, Is.EqualTo(1));
      Assert.That(result.Artists[0].Name, Is.EqualTo("wow"));
      
      mRequestHandler.Verify();
    }

    [SetUp]
    public void DoSetup() {
      mRequestHandler = new Mock<IRequestHandler>(MockBehavior.Strict);
      mRunner = new Runner(mRequestHandler.Object);
    }

    public Mock<IRequestHandler> mRequestHandler;
    public Runner mRunner;
  }
}

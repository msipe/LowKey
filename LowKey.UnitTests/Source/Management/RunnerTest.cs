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
    public void TestRunnerInitsSimilarArtistRequestAndReturnsSimilarArtistsArrayWithNoItems() {
      var request = new GetSimilarArtistsRequest("artist", "key3");
      var message = new HttpResponseMessage();
      mRequestHandler
        .Setup(s => s.SendRequest(request))
        .Returns(message)
        .Verifiable();

      mRequestHandler
        .Setup(r => r.ReadRequest(message))
        .Returns("{}")
        .Verifiable();
      
      var result = mRunner.InitSimilarArtistsRequest(request);

      Assert.IsNull(result.Artists);
      
      mRequestHandler.Verify();
    }

    [Test]
    public void TestRunnerInitsSimilarArtistRequestAndReturnsSimilarArtistsArrayWithOneItem() {
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

    [Test]
    public void TestRunnerInitsSimilarArtistRequestAndReturnsSimilarArtistsArrayWithMultipleItems() {
      var request = new GetSimilarArtistsRequest("artist", "key3");
      var message = new HttpResponseMessage();
      mRequestHandler
        .Setup(s => s.SendRequest(request))
        .Returns(message)
        .Verifiable();

      mRequestHandler
        .Setup(r => r.ReadRequest(message))
        .Returns("{'Artists':[{'Name':'123'},{'Name':'wow'},{'Name':'rtf'}]}")
        .Verifiable();

      var result = mRunner.InitSimilarArtistsRequest(request);

      Assert.That(result.Artists.Length, Is.EqualTo(3));
      Assert.That(result.Artists[0].Name, Is.EqualTo("123"));
      Assert.That(result.Artists[1].Name, Is.EqualTo("wow"));
      Assert.That(result.Artists[2].Name, Is.EqualTo("rtf"));

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

using LowKey.Core.Source.Api;
using LowKey.Core.Source.Management;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;

namespace LowKey.UnitTests.Source.Management {
  [TestFixture]
  public class SimilarArtistHandlerTest {
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

      Assert.IsNull(result.SimilarArtists);
      
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
        .Returns("{'similarartists':{'artist': [{'Name':'wow'}]}}")
        .Verifiable();

      var result = mRunner.InitSimilarArtistsRequest(request);

      Assert.That(result.SimilarArtists.Artist.Length, Is.EqualTo(1));
      Assert.That(result.SimilarArtists.Artist[0].Name, Is.EqualTo("wow"));

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
        .Returns("{'similarartists':{'artist': [{'Name':'123'},{'Name':'wow'},{'Name':'rtf'}]}}")
        .Verifiable();

      var result = mRunner.InitSimilarArtistsRequest(request);

      Assert.That(result.SimilarArtists.Artist.Length, Is.EqualTo(3));
      Assert.That(result.SimilarArtists.Artist[0].Name, Is.EqualTo("123"));
      Assert.That(result.SimilarArtists.Artist[1].Name, Is.EqualTo("wow"));
      Assert.That(result.SimilarArtists.Artist[2].Name, Is.EqualTo("rtf"));

      mRequestHandler.Verify();
    }

    [SetUp]
    public void DoSetup() {
      mRequestHandler = new Mock<IRequestHandler>(MockBehavior.Strict);
      mRunner = new SimilarArtistHandler(mRequestHandler.Object);
    }

    public Mock<IRequestHandler> mRequestHandler;
    public SimilarArtistHandler mRunner;
  }
}

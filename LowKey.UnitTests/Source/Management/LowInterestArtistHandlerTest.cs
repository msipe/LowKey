using NUnit.Framework;
using LowKey.Core.Source.Management;
using LowKey.Core.Source.Management.Mappings;
using LowKey.Core.Source.Api;
using Moq;
using System.Collections;
using System.Net.Http;
using System.Collections.Generic;

namespace LowKey.UnitTests.Source.Management {
  [TestFixture]
  public class LowInterestArtistHandlerTest {

    [Test]
    public void TestHandlerPullsCorrectArtistAmountWithZeroArtists() {
      var handler = new LowInterestArtistHandler(mRequestHandler.Object, "key");
      var results = handler.PullArtistData(new SimilarArtists(new Artist[] {}));
      Assert.IsEmpty(results);
    }
    [Test]
    public void TestHandlerPullsCorrectArtistAmountWithSingleArtist() {
      var handler = new LowInterestArtistHandler(mRequestHandler.Object, "key");
      var queue = new Queue<string>();
      queue.Enqueue("{'name':'artist name'}");
      mRequestHandler.Setup(h => h.SendRequest(It.IsAny<GetArtistInfoRequest>())).Returns(new HttpResponseMessage());
      mRequestHandler.Setup(h => h.ReadRequest(It.IsAny<HttpResponseMessage>())).Returns(queue.Dequeue());
      var results = handler.PullArtistData(CreateBatchOfSimilarArtists(1));
      Assert.That(results.Length, Is.EqualTo(1));
      Assert.That(results[0].Name, Is.EqualTo("artist name"));
    }

    [SetUp]
    public void DoSetup() {
      mRequestHandler = new Mock<IRequestHandler>(MockBehavior.Strict);
    }

    private Mock<IRequestHandler> mRequestHandler;

    private SimilarArtists CreateBatchOfSimilarArtists(int numNeeded) {
      var batch = new Artist[numNeeded];

      for (var x = 0; x < numNeeded; x++) {
        batch[x] = new Artist(x.ToString());
      }

      return new SimilarArtists(batch);
    }
  }
}

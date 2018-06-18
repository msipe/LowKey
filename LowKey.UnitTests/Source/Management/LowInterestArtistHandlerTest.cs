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
      var results = mLowInterestArtistHandler.PullArtistData(new SimilarArtists(new Artist[] {}));
      Assert.IsEmpty(results);
    }

    [Test]
    public void TestHandlerPullsCorrectArtistAmountWithSingleArtist() {
      var queue = new Queue<string>();
      queue.Enqueue("{'name':'artist name', 'stats':{'listeners':76, 'playcount':12}}");
      mRequestHandler.Setup(h => h.SendRequest(It.IsAny<GetArtistInfoRequest>())).Returns(new HttpResponseMessage());
      mRequestHandler.Setup(h => h.ReadRequest(It.IsAny<HttpResponseMessage>())).Returns(queue.Dequeue());
      var results = mLowInterestArtistHandler.PullArtistData(CreateBatchOfSimilarArtists(1));
      Assert.That(results.Length, Is.EqualTo(1));
      Assert.That(results[0].Name, Is.EqualTo("artist name"));
      Assert.That(results[0].Stats.Listeners, Is.EqualTo(76));
      Assert.That(results[0].Stats.Playcount, Is.EqualTo(12));
    }

    [Test]
    public void TestHandlerPullsCorrectArtistAmountWith5Artists() {
      var queue = new Queue<string>();
      queue.Enqueue("{'name':'artist 1', 'stats':{'listeners':1, 'playcount':2}}");
      queue.Enqueue("{'name':'artist 2'}");
      queue.Enqueue("{'name':'despacito'}");
      queue.Enqueue("{'name':'artist 4'}");
      queue.Enqueue("{'name':'bilbo', 'stats':{'listeners':23, 'playcount':25}}");

      mRequestHandler.Setup(h => h.SendRequest(It.IsAny<GetArtistInfoRequest>())).Returns(new HttpResponseMessage());
      mRequestHandler.Setup(h => h.ReadRequest(It.IsAny<HttpResponseMessage>())).Returns(queue.Dequeue);
     
      var results = mLowInterestArtistHandler.PullArtistData(CreateBatchOfSimilarArtists(5));
      Assert.That(results.Length, Is.EqualTo(5));
      Assert.That(results[0].Name, Is.EqualTo("artist 1"));
      Assert.That(results[0].Stats.Listeners, Is.EqualTo(1));
      Assert.That(results[0].Stats.Playcount, Is.EqualTo(2));
      Assert.That(results[1].Name, Is.EqualTo("artist 2"));
      Assert.That(results[2].Name, Is.EqualTo("despacito"));
      Assert.That(results[3].Name, Is.EqualTo("artist 4"));
      Assert.That(results[4].Name, Is.EqualTo("bilbo"));
      Assert.That(results[4].Stats.Listeners, Is.EqualTo(23));
      Assert.That(results[4].Stats.Playcount, Is.EqualTo(25));
    }

    [Test]
    public void TestHandlerSelectsLowInterestArtistsWithASingleArtist() {
      var aboveCutoffArtist = new[] {
        new Artist("a1") {Stats=new ArtistStats(17,2)},
      };

      var belowCutoffArtist = new[] {
        new Artist("a2") {Stats=new ArtistStats(3,2)},
      };

      var expectedAbove = mLowInterestArtistHandler.SelectLowInterestArtists(aboveCutoffArtist, 15);
      var expectedBelow = mLowInterestArtistHandler.SelectLowInterestArtists(belowCutoffArtist, 15);

      Assert.IsEmpty(expectedAbove);
      Assert.That(expectedBelow.Length, Is.EqualTo(1));
      Assert.That(expectedBelow[0].Name, Is.EqualTo("a2"));
    }

    [Test]
    public void TestHandlerSelectsLowInterestArtistsWithMultipleArtists() {
      var artists = new[] {
        new Artist("a1") {Stats=new ArtistStats(3,2)},
        new Artist("a2") {Stats=new ArtistStats(17,3)},
        new Artist("a3") {Stats=new ArtistStats(12,4)},
      };
      var results = mLowInterestArtistHandler.SelectLowInterestArtists(artists, 15);

      Assert.That(results.Length, Is.EqualTo(2));
      Assert.That(results[0].Name, Is.EqualTo("a1"));
      Assert.That(results[1].Name, Is.EqualTo("a3"));
    }

    [SetUp]
    public void DoSetup() {
      mRequestHandler = new Mock<IRequestHandler>(MockBehavior.Strict);
      mLowInterestArtistHandler = new LowInterestArtistHandler(mRequestHandler.Object, "key");
    }

    private Mock<IRequestHandler> mRequestHandler;
    private LowInterestArtistHandler mLowInterestArtistHandler;

    private SimilarArtists CreateBatchOfSimilarArtists(int numNeeded) {
      var batch = new Artist[numNeeded];

      for (var x = 0; x < numNeeded; x++) {
        batch[x] = new Artist(x.ToString());
      }

      return new SimilarArtists(batch);
    }
  }
}

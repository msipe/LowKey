using NUnit.Framework;
using LowKey.Core.Source.Management;

namespace LowKey.UnitTests.Source.Management {
  [TestFixture]
  public class LowInterestArtistHandlerTest {
    [Test]
    public void TestHandlerSelects30PossibleArtists() {
      var handler = new LowInterestArtistHandler();
      var results = handler.LookForCandidateArtists();
      Assert.That(results.Artists.Length, Is.EqualTo(1));
    }  
  }
}

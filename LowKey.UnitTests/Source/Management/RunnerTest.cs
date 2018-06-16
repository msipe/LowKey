using LowKey.Core.Source.Api;
using LowKey.Core.Source.Management;
using Moq;
using NUnit.Framework;

namespace LowKey.UnitTests.Source.Management {
  [TestFixture]
  public class RunnerTest {
    [Test]
    public void TestRunnerExecutesGetInitArtistWithCorrectArgs() {
      var runner = new Runner(mRequestHandler.Object);
    }

    [SetUp]
    public void DoSetup() {
      mRequestHandler = new Mock<IRequestHandler>(MockBehavior.Strict);
    }

    public Mock<IRequestHandler> mRequestHandler;
  }
}

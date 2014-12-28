using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonix.Tests
{
    [TestClass]
    public class MetaphoneTests
    {
        public TestContext TestContext { get; set; }

        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfi", "Spotifi" };
        readonly Metaphone _generator = new Metaphone();

        [TestMethod]
        public void Should_Validate_Similar_Words()
        {
            Assert.IsTrue(_generator.IsSimilar(Words));
        }
    }
}

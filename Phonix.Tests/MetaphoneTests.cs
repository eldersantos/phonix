using NUnit.Framework;

namespace Phonix.Tests
{
    [TestFixture]
    public class MetaphoneTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfi", "Spotifi" };
        readonly Metaphone _generator = new Metaphone();

        [Test]
        public void Should_Validate_Similar_Words()
        {
            Assert.IsTrue(_generator.IsSimilar(Words));
        }
    }
}

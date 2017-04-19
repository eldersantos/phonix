using Xunit;

namespace Phonix.Tests
{
    public class MetaphoneTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfi", "Spotifi" };
        readonly Metaphone _generator = new Metaphone();

        [Fact]
        public void Should_Validate_Similar_Words()
        {
            Assert.True(_generator.IsSimilar(Words));
        }
    }
}

using Xunit;

namespace Phonix.Tests
{
    public class MatchRatingApproachTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfy","Sputfi" };

        readonly MatchRatingApproach _generator = new MatchRatingApproach();


        [Fact]
        public void Should_Be_Similar()
        {
            Assert.True(_generator.IsSimilar(Words));
        }
    }
}

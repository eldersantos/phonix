using NUnit.Framework;

namespace Phonix.Tests
{
    [TestFixture]
    public class MatchRatingApproachTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfy","Sputfi" };

        readonly MatchRatingApproach _generator = new MatchRatingApproach();


        [Test]
        public void Should_Be_Similar()
        {
            Assert.IsTrue(_generator.IsSimilar(Words));
        }
    }
}

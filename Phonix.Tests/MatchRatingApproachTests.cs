using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonix.Tests
{
    [TestClass]
    public class MatchRatingApproachTests
    {
        public TestContext TestContext { get; set; }

        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfy" };

        readonly MatchRatingApproach _generator = new MatchRatingApproach();


        [TestMethod]
        public void Should_MatchRatings()
        {
            string[][] keys = new string[Words.Length][];
            for (int n = 0; n < Words.Length; n++)
            {
                keys[n] = _generator.GenerateKeys(Words[n]);
            }

            for (int n = 0; n < Words.Length; n++)
            {
                for (int m = 0; m < keys[n].Length; m++)
                {
                    TestContext.WriteLine(keys[n][m]);
                    if (n > 0)
                    {
                        TestContext.WriteLine(_generator.MatchRatingCompute(keys[n][m], keys[n - 1][m]).ToString());
                    }
                }
            }
        }
    }
}

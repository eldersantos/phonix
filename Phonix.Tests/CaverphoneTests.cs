using NUnit.Framework;

namespace Phonix.Tests
{
    [TestFixture]
    public class CaverphoneTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfi", "Spotifi" };
        readonly CaverPhone _generator = new CaverPhone();

        [Test]
        public void Should_Return_Correct_Key()
        {
            string[][] keys = new string[Words.Length][];
            for (int n = 0; n < Words.Length; n++)
            {
                keys[n] = _generator.BuildKeys(Words[n]);
            }

            for (int n = 0; n < Words.Length; n++)
            {
                for (int m = 0; m < keys[n].Length; m++)
                {
                    if (n > 0)
                    {
                        Assert.AreEqual(keys[n][m], keys[n - 1][m]);
                    }
                }
            }
        }
    }
}

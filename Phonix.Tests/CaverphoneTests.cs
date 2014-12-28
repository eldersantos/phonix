using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonix.Tests
{
    [TestClass]
    public class CaverphoneTests
    {
        public TestContext TestContext { get; set; }

        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfi", "Spotifi" };
        readonly CaverPhone _generator = new CaverPhone();

        [TestMethod]
        public void Should_Return_Correct_Key()
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
                        Assert.AreEqual(keys[n][m], keys[n - 1][m]);
                    }
                }
            }
        }
    }
}

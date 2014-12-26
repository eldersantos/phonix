using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonix.Tests
{
    [TestClass]
    public class DoubleMetaphoneTests
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        private static readonly string[] Words = new[] {"Spotify", "Spotfy", "Sputfi", "Spotifi"};
        private static readonly string[] Words2 = new[] { "Airbnb", "Airbandb"};


        readonly DoubleMetaphone _generator =  new DoubleMetaphone();
        
        [TestMethod]
        public void Should_Return_Same_Keys()
        {
            string[][] keys =  new string[Words.Length][];
            for (int n = 0; n < Words.Length; n++)
            {
                keys[n] =  _generator.GenerateKeys(Words[n]);
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

            string[][] keys2 = new string[Words2.Length][];
            for (int n = 0; n < Words2.Length; n++)
            {
                keys2[n] = _generator.GenerateKeys(Words2[n]);
            }

            for (int n = 0; n < Words2.Length; n++)
            {
                for (int m = 0; m < keys2[n].Length; m++)
                {
                    TestContext.WriteLine(keys2[n][m]);
                    if (n > 0)
                    {
                        Assert.AreEqual(keys2[n][m], keys2[n - 1][m]);
                    }
                }
            }
        }
    }
}

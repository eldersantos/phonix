using System;
using NUnit.Framework;

namespace Phonix.Tests
{
    [TestFixture]
    public class DoubleMetaphoneTests
    {
        private static readonly string[] Words = new[] {"Spotify", "Spotfy", "Sputfi", "Spotifi"};
        private static readonly string[] Words2 = new[] { "United Air Lines", "United Aire Lines", "Unitid Air Line"};

        readonly DoubleMetaphone _generator =  new DoubleMetaphone();
        
        [Test]
        public void Should_Return_Same_Keys()
        {
            string[][] keys =  new string[Words.Length][];
            for (int n = 0; n < Words.Length; n++)
            {
                keys[n] =  _generator.BuildKeys(Words[n]);
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

            string[][] keys2 = new string[Words2.Length][];
            for (int n = 0; n < Words2.Length; n++)
            {
                keys2[n] = _generator.BuildKeys(Words2[n]);
            }

            for (int n = 0; n < Words2.Length; n++)
            {
                for (int m = 0; m < keys2[n].Length; m++)
                {
                    Console.WriteLine(keys2[n][m]);
                    if (n > 0)
                    {
                        Assert.AreEqual(keys2[n][m], keys2[n - 1][m]);
                    }
                }
            }
        }
    }
}

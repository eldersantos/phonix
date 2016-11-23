Welcome to Phonix
======

A Phonetic open source libray for .NET, no dependencies, it is pure C# code ;)
Now with support for .NET Core (thanks @ysilvestrov)

Latest Version
--------------

The quickest way to get the latest release of Phonix is to add it to your project using 
NuGet (<http://nuget.org/List/Packages/Phonix>).

Implemented algorithms
----------------

Today Phonix implements the following algorithms:

* Caverphone [http://en.wikipedia.org/wiki/Caverphone] - Created by David Hood, the algorithm is optimised for accents.
* Double Metaphone [http://en.wikipedia.org/wiki/Metaphone] - Phonetic encoding algorithm is the second generation of the Metaphone algorithm
* Metaphone [http://en.wikipedia.org/wiki/Metaphone] - Published by Lawrence Philips in 1990, for indexing words by their English pronunciation.
* Match Rating [http://en.wikipedia.org/wiki/Match_rating_approach] - Is a phonetic algorithm developed by Western Airlines in 1977 for the indexation and comparison of homophonous names
* Soundex [http://en.wikipedia.org/wiki/Soundex] - Is a phonetic algorithm for indexing names by sound, as pronounced in English.

How to use
---------------

Below there are examples on how to use the MatchRating, DoubleMetaphone and Soundex algorithms:

```

    using Phonix;
    
    public class MatchRatingApproachTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfy","Sputfi" };

        readonly MatchRatingApproach _generator = new MatchRatingApproach();
       
        public void Should_Be_Similar()
        {
            Console.Writeline(_generator.IsSimilar(Words));
        }
    }
    
    public class SoundexTests
    {
        private static readonly string[] Words = new[] { "Spotify", "Spotfy", "Sputfi", "Spotifi" };
        private static readonly string[] Words2 = new[] { "United Air Lines", "United Aire Lines", "United Air Line" };

        readonly Soundex _generator = new Soundex();

        public void Should_Be_Similar()
        {
            Console.Writeline(_generator.IsSimilar(Words));
            Console.Writeline(_generator.IsSimilar(Words2));
        }
    }
    
    public class DoubleMetaphoneTests
    {
        private static readonly string[] Words = new[] {"Spotify", "Spotfy", "Sputfi", "Spotifi"};
        private static readonly string[] Words2 = new[] { "United Air Lines", "United Aire Lines", "Unitid Air Line"};

        readonly DoubleMetaphone _generator =  new DoubleMetaphone();
              
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
                        Console.Writeline(keys[n][m], keys[n - 1][m]);
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
                        Console.Writeline(keys2[n][m], keys2[n - 1][m]);
                    }
                }
            }
        }
    }
```

using System.Text;
using System.Text.RegularExpressions;

namespace Phonix
{
    internal static class MatchRatingC
    {

        public static bool GenerateMatchRating(string name, out string key)
        {
            key = string.Empty;

            //preprocess
            if (string.IsNullOrEmpty(name)) { return false; }

            //undocumented make all upper case
            string upperName = name.ToUpper();
            //Let's strip non A-Z characters
            upperName = Regex.Replace(upperName, "[^A-Z]", string.Empty, RegexOptions.Compiled);


            //Delete all vowels unless the vowel begins the word
            if (upperName.Length > 1)
            {
                string start = upperName[0].ToString();
                upperName = start + SioHelpers.Vowels.Replace(upperName.Substring(1), string.Empty);
            }

            //Remove the second consonant of any double consonants present
            upperName = CollapseRepeatingConsonants(upperName);

            //Reduce codex to 6 letters by joining the first 3 and last 3 letters only
            int length = upperName.Length;
            if (length > 6)
            {
                upperName = upperName.Substring(0, 3) + upperName.Substring(length - 3, 3);
            }

            key = upperName;

            return true;
        }


        internal static string CollapseRepeatingConsonants(string name)
        {
            StringBuilder sb = new StringBuilder();

            char prev = ' ';
            bool first = true;
            foreach (char c in name)
            {
                if (c != prev || first || SioHelpers.IsVowel(c))
                {
                    sb.Append(c);
                    first = false;
                }
                prev = c;
            }

            return sb.ToString();
        }



        internal static int MatchRatingCompute(string name1, string name2)
        {
            //0 is an impossible rating, it will mean unrated
            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2)) { return 0; }

            string large;
            string small;

            if (name1.Length >= name2.Length)
            {
                large = name1.ToUpper();
                small = name2.ToUpper();
            }
            else
            {
                large = name2.ToUpper();
                small = name1.ToUpper();
            }

            int x = large.Length;
            int y = small.Length;

            //If the length difference between the encoded strings is 3 or greater, then no similarity comparison is done.
            if ((x - y) > 3) { return 0; }

            //Obtain the minimum rating value by calculating the length sum of the encoded strings and using table A
            int minRating = MinimumRating(x + y);


            //Process the encoded strings from left to right and remove any identical characters found from both strings respectively.
            for (int i = 0; i < small.Length; )
            {
                bool found = false;
                for (int j = 0; j < large.Length; j++)
                {
                    if (small[i] == large[j])
                    {
                        small = small.Remove(i, 1);
                        large = large.Remove(j, 1);
                        found = true;
                    }
                }

                if (!found)
                {
                    i++;
                }
            }

            large = SioHelpers.ReverseString(large);
            small = SioHelpers.ReverseString(small);


            //Process the unmatched characters from right to left and remove any identical characters found from both names respectively.
            for (int i = 0; i < small.Length; )
            {
                bool found = false;
                for (int j = 0; j < large.Length; j++)
                {
                    if (small[i] == large[j])
                    {
                        small = small.Remove(i, 1);
                        large = large.Remove(j, 1);
                        found = true;
                    }
                }

                if (!found)
                {
                    i++;
                }
            }

            //Subtract the number of unmatched characters from 6 in the longer string. This is the similarity rating.
            int rating = 6 - (large.Length);

            //If the similarity rating equal to or greater than the minimum rating then the match is considered good.
            if (rating >= minRating) { return rating; }

            return 0;
        }

        private static int MinimumRating(int sum)
        {
            // ≤ 4	5
            //4 < sum ≤ 7	4
            //7 < sum ≤ 11	3
            //= 12	2

            if (sum <= 4) { return 5; }
            if (sum <= 7) { return 4; }
            if (sum <= 11) { return 3; }
            if (sum == 12) { return 2; }

            return 0;
        }
    }
}

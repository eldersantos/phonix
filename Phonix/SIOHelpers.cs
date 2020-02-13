using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Phonix
{
    internal static class SioHelpers
    {

        public static Regex Vowels = new Regex("[AEIOUaeiou]", RegexOptions.Compiled);

        /// <summary>
        /// Collapses on adjacent repeating letters in a string into one single character.
        /// 
        /// EXAMPLE:
        /// Hello -> Helo
        /// Bobby - > Boby
        /// </summary>
        /// <param name="value">value to collapse adjacent characters</param>
        /// <returns>Collapsed string</returns>
        public static string CollapseAdjacentRepeating(string value)
        {
            var sb = new StringBuilder();

            var prev = ' ';
            var first = true;
            foreach (var c in value)
            {
                if (c != prev || first)
                {
                    sb.Append(c);
                    first = false;
                }
                prev = c;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Checks if a character is a vowel.
        /// 
        /// Should be faster than regex.
        /// </summary>
        /// <param name="c">Character to check</param>
        /// <returns>true if it is a vowel</returns>
        public static bool IsVowel(char c)
        {
            switch (c)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return true;
                default:
                    return false;
            }
        }


        /// <summary>
        /// Reverses the order of a string
        /// </summary>
        /// <param name="value">String to reverse</param>
        /// <returns>Reversed string</returns>
        public static string ReverseString(string value)
        {
            var valArray = value.ToCharArray();
            Array.Reverse(valArray);
            return new string(valArray);
        }


        /// <summary>
        /// Compute Levenhstein Distance
        /// 
        /// Translating pseudocode from wiki
        /// http://en.wikipedia.org/wiki/Levenshtein_distance
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int LevenshteinDistance(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                throw new ArgumentException("Neither string can be null for Levenshtein Distance calculations.");
            }

            var s1L = s1.Length;
            var s2L = s2.Length;
            var d = new int[s1L, s2L];

            for (var i = 0; i < s1L; i++)
            {
                d[i, 0] = i; // deletion
            }

            for (var j = 0; j < s2L; j++)
            {
                d[0, j] = j; // insertion
            }

            for (var j = 1; j < s2L; j++)
            {
                for (var i = 1; i < s1L; i++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];
                    }
                    else
                    {
                        var deletion = d[i - 1, j] + 1;
                        var insertion = d[i, j - 1] + 1;
                        var substitution = d[i - 1, j - 1] + 1;

                        var min1 = Math.Min(deletion, insertion);
                        var min2 = Math.Min(min1, substitution);

                        d[i, j] = min2;
                    }
                }
            }

            return d[s1L - 1, s2L - 1];
        }


        /// <summary>
        /// Compute Hamming Distance.
        /// Can only be used on strings of equal length
        /// </summary>
        /// <param name="s1">String 1 to compare</param>
        /// <param name="s2">String 2 to compare</param>
        /// <returns>the calculated distance. 
        /// Values are 0 and up. 
        /// -1 is returned if the strings are NOT of equal length 
        /// (use LevenshteinDistance for unequal length strings)</returns>
        public static int HammingDistance(string s1, string s2)
        {
            if (s1 == null || s2 == null)
            {
                throw new ArgumentException("Neither string can be null for Hamming Distance calculations.");
            }

            if (s1.Length != s2.Length)
            {
                //throw new ArgumentException("Strings must be of equal length to accurately Calculate Hamming Distance.");
                //for now, let's return -1 instead of throwing an error
                return -1;
            }


            s1 = s1.ToLower();
            s2 = s2.ToLower();

            return s1.Where((t, i) => t.Equals(s2[i])).Count();
        }


        /// <summary>
        /// Calculates the Dice Coefficient (similarity) of two strings.
        /// 
        /// http://en.wikipedia.org/wiki/Dice%27s_coefficient
        /// 
        /// </summary>
        /// <param name="s1">First string to calculate the Dice Coefficient of</param>
        /// <param name="s2">Second string to calculate the Dice Coefficient of</param>
        /// <returns>the calculated coefficient</returns>
        public static float DiceCoefficient(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();

            var s1BiGrams = NGram.GenerateNGram(s1, 2, true);
            var s2BiGrams = NGram.GenerateNGram(s2, 2, true);

            //intersecting members
            var intersects = s1BiGrams.Intersect(s2BiGrams).ToList();

            //(2 x IntersectingCNT) / (total added bigrams)
            return (float)(2 * intersects.Count) / (float)(s2BiGrams.Count + s1BiGrams.Count);
        }
    }
}

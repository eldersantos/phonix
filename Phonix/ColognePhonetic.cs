using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Phonix.Similarity;

namespace Phonix
{
    /// <summary>
    /// Implements the conversion of words to phonetic Codes by application of Cologne phonetics rules.
    /// </summary>
    /// <remarks>
    /// Cologne phonetics is supposed to yield better results than Soundex regarding German words.
    /// Contrary to Soundex, the length of the phonetic Code is not limited.
    /// </remarks>
    public class ColognePhonetic : ISimilarity
    {
        private static readonly char[] group0 = new[] { 'A', 'E', 'I', 'J', 'O', 'U', 'Y', 'Ä', 'Ö', 'Ü' };

        private static readonly char[] group3 = new[] { 'F', 'V', 'W' };

        private static readonly char[] group4 = new[] { 'G', 'K', 'Q', };

        private static readonly char[] group6 = new[] { 'M', 'N' };

        private static readonly char[] group8 = new[] { 'S', 'Z', 'ß' };

        private static readonly char[] groupCFirst = new[] { 'A', 'H', 'K', 'L', 'O', 'Q', 'R', 'U', 'X' };

        private static readonly char[] groupCNoFirst = new[] { 'A', 'H', 'K', 'O', 'Q', 'U', 'X' };

        private static readonly char[] groupCPrevious = new[] { 'S', 'Z' };

        private static readonly char[] groupDTPrevious = new[] { 'C', 'S', 'Z' };

        private static readonly char[] groupXFollow = new[] { 'C', 'K', 'Q' };

        public static string BuildKey(string input)
        {
            var content = input.ToUpperInvariant().ToCharArray();

            // hold result in StringBuilder
            var sb = new StringBuilder();

            for (var i = 0; i < content.Length; i++)
            {
                var entry = content[i];

                // ignore non-letters
                if (!char.IsLetter(entry))
                {
                    continue;
                }

                // ignore H
                if (entry.Equals('H'))
                {
                    continue;
                }

                // check if entry is part of the standard value groups

                if (group0.Contains(entry))
                {
                    sb.Append("0");
                    continue;
                }

                if (group3.Contains(entry))
                {
                    sb.Append("3");
                    continue;
                }

                if (group4.Contains(entry))
                {
                    sb.Append("4");
                    continue;
                }

                if (group6.Contains(entry))
                {
                    sb.Append("6");
                    continue;
                }

                if (group8.Contains(entry))
                {
                    sb.Append("8");
                    continue;
                }

                switch (entry)
                {
                    case 'B':
                        sb.Append("1");
                        continue;
                    case 'L':
                        sb.Append("5");
                        continue;
                    case 'R':
                        sb.Append("7");
                        continue;
                    // check if character is in a special value group
                    // last letter in array?
                    case 'P' when i + 1 >= content.Length:
                        sb.Append("1");
                        continue;
                    case 'P':
                    {
                        var next = content[i + 1];

                        // if followed by "H"
                        if (next.Equals('H'))
                        {
                            sb.Append("3");
                            continue;
                        }

                        sb.Append("1");
                        continue;
                    }

                    // if first letter
                    case 'X' when i == 0:
                        sb.Append("48");
                        continue;
                    case 'X':
                    {
                        var previous = content[i - 1];

                        // compare with previous
                        if (groupXFollow.Contains(previous))
                        {
                            sb.Append("8");
                            continue;
                        }

                        sb.Append("48");
                        continue;
                    }

                    case 'D':
                    case 'T':
                    {
                        // last letter in array?
                        if (i + 1 >= content.Length)
                        {
                            sb.Append("2");
                            continue;
                        }

                        var next = content[i + 1];

                        // is next value in special value group?
                        if (groupDTPrevious.Contains(next))
                        {
                            sb.Append("8");
                            continue;
                        }

                        sb.Append("2");
                        continue;
                    }

                    // if first letter
                    case 'C' when i == 0:
                    {
                        var next = content[i + 1];

                        // if next letter is in same group
                        if (groupCFirst.Contains(next))
                        {
                            sb.Append("4");
                            continue;
                        }

                        sb.Append("8");
                        continue;
                    }

                    // not first letter
                    // last letter?
                    case 'C' when i + 1 >= content.Length:
                        continue;
                    case 'C':
                    {
                        var next = content[i + 1];
                        var previous = content[i - 1];

                        // is previous letter in same group?
                        if (groupCPrevious.Contains(previous))
                        {
                            sb.Append("8");
                            continue;
                        }
                        else
                        {
                            // is next letter in same group?
                            if (groupCNoFirst.Contains(next))
                            {
                                sb.Append("4");
                                continue;
                            }

                            sb.Append("8");
                            continue;
                        }
                    }
                }
            }

            return sb.ToString();
        }

        public static string CleanDoubles(string input)
        {
            var sb = new StringBuilder();
            var content = input.ToCharArray();
            var previous = new char();

            foreach (var entry in content)
            {
                if (!entry.Equals(previous))
                {
                    sb.Append(entry);
                }
                previous = entry;
            }
            return sb.ToString();
        }

        public static string CleanZeros(string input)
        {
            var sb = new StringBuilder();
            var content = input.ToCharArray();

            for (var i = 0; i < content.Length; i++)
            {
                var entry = content[i];

                // skip all zeros except in first place
                if (!entry.Equals('0') || i == 0)
                {
                    sb.Append(entry);
                }
            }
            return sb.ToString();
        }

        public bool IsSimilar(string[] words)
        {
            var encoders = new string[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                var keys = BuildKey(words[i]);
                keys = CleanDoubles(keys);
                keys = CleanDoubles(keys);
                encoders[i] = keys;
                if (i == 0) continue;
                if (encoders[i] != encoders[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

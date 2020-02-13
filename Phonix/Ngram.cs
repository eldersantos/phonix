using System;
using System.Collections.Generic;

namespace Phonix
{
    internal sealed class NGram
    {
        public static List<string> GenerateNGram(string name, int n, bool removeSpaces)
        {
            if (n <= 0)
            {
                throw new ArgumentException("NGram size must be greater than 0.");
            }

            var grams = new List<string>();

            //if the name is null, empty, or if we're removing spaces and it is only spaces then return an empty list
            if (string.IsNullOrEmpty(name) || (removeSpaces && string.IsNullOrEmpty(name.Trim()))) { return grams; }

            //removeSpaces if requested
            if (removeSpaces)
            {
                name = name.Replace(" ", string.Empty);
            }

            if (n >= name.Length) return grams;
            for (var i = 0; (i + n) <= name.Length; i++)
            {
                grams.Add(name.Substring(i, n));
            }

            return grams;
        }
    }
}

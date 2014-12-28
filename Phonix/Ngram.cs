using System;
using System.Collections.Generic;
using Phonix.Encoding;

namespace Phonix
{
    public sealed class NGram : PhoneticEncoder
    {
        public static List<string> GenerateNGram(string name, int n, bool removeSpaces)
        {
            if (n <= 0)
            {
                throw new ArgumentException("NGram size must be greater than 0.");
            }

            List<string> grams = new List<string>();

            //if the name is null, empty, or if we're removing spaces and it is only spaces then return an empty list
            if (string.IsNullOrEmpty(name) || (removeSpaces && string.IsNullOrEmpty(name.Trim()))) { return grams; }

            //removeSpaces if requested
            if (removeSpaces)
            {
                name = name.Replace(" ", string.Empty);
            }


            if (n < name.Length)
            {
                for (int i = 0; (i + n) <= name.Length; i++)
                {
                    grams.Add(name.Substring(i, n));
                }
            }
            else
            {   //really not sure what to do here if the length is less than the required q gram size

                //grams.Add(name);
            }
            return grams;
        }

        public override string[] GenerateKeys(string word)
        {
            throw new NotImplementedException();
        }

        public override string GenerateKey(string word)
        {
            throw new NotImplementedException();
        }
    }
}

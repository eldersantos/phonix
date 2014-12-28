using System;
using Phonix.Encoding;

namespace Phonix
{

    /// <summary> Abstract base class of "metaphone"-encoders.
    /// 
    /// </summary>
    public abstract class MetaphoneEncoder : PhoneticEncoder
    {
        protected internal int MaxLength;

        /// <summary> Constructs a phonetic encoder of type "metaphone".</summary>
        /// <param name="maxLength">the maximal length of the keys to generate by
        /// this <code>MetaphoneEncoder</code>. If the given
        /// length is lower than zero, the lengths of the generated
        /// keys are only limited by the size of the words to encode.
        /// </param>
        protected MetaphoneEncoder(int maxLength)
        {
            MaxLength = maxLength;
        }

        protected internal static bool IsVowel(string stringRenamed, int pos)
        {
            if (pos < 0 || stringRenamed.Length <= pos)
                return false;

            char c = stringRenamed[pos];
            return c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
        }

        protected internal static bool Match(string stringRenamed, int pos, string[] strings)
        {
            if (0 <= pos && pos < stringRenamed.Length)
            {
                for (int n = strings.Length - 1; n >= 0; n--)
                {
                    if (String.Compare(stringRenamed, pos, strings[n], 0, strings[n].Length) == 0)
                        return true;
                }
            }
            return false;
        }

        protected internal static bool Match(string stringRenamed, int pos, char c)
        {
            return (0 <= pos && pos < stringRenamed.Length) && stringRenamed[pos] == c;
        }
    }
}
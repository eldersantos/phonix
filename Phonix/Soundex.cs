using System;
using Phonix.Encoding;
using Phonix.Similarity;

namespace Phonix
{
    /// <summary> Encoder implementing the phonetic algorithm "Soundex".
    /// Soundex is described in Donald Knuth's
    /// <i>The Art of Computer Programming</i>, Vol.3.
    /// 
    /// </summary>
    /// <seealso cref="Metaphone">
    /// </seealso>
    /// <seealso cref="DoubleMetaphone">
    /// </seealso>
    public sealed class Soundex : PhoneticEncoder, ISimilarity
    {
        private readonly bool _full;
        private readonly int _length;

        /// <summary> Constructs a Soundex encoder which generates keys of given length.</summary>
        /// <param name="full">a flag which specifies, whether the first character has to
        /// to be encoded, or not. If <code>false</code>, then this encoder works
        /// like the original soundex described by Knuth, i.e. 'Knuth'
        /// will become 'K530'. If <code>true</code>, then this encoder will encode
        /// the first character too, i.e. 'Knuth' will become '2530'.
        /// </param>
        /// <param name="length">the length of the keys to generate.
        /// </param>
        public Soundex(bool full, int length)
        {
            _full = full;
            _length = length;
        }

        /// <summary> Constructs a Soundex encoder which generates keys of length 4.</summary>
        /// <param name="full">a flag which specifies, whether the first character has to
        /// to be encoded, or not. If <code>false</code>, this encoder works
        /// like the original soundex described by Knuth, i.e. 'Knuth'
        /// will become 'K530'. If <code>true</code>, this encoder will encode
        /// the first character too, i.e. 'Knuth' will become '2530'.
        /// </param>
        public Soundex(bool full): this(full, 4)
        {
        }

        /// <summary> Constructs an original Soundex encoder which generates keys of given length.</summary>
        /// <param name="length">the length of the keys to generate.
        /// </param>
        public Soundex(int length): this(false, length)
        {
        }

        /// <summary> Constructs an original Soundex encoder which generates keys of length 4.</summary>
        public Soundex(): this(false, 4)
        {
        }

        /// <summary> Returns a <tt>String</tt> identifying the algorithm.</summary>
        public override string ToString()
        {
            return "Soundex_" + _full + "_" + _length;
        }

        public bool IsSimilar(string[] words)
        {
            string[] encoders = new string[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                encoders[i] = BuildKey(words[i]);
                if (i != 0)
                {
                    if (encoders[i] != encoders[i - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static char GETCode(char c)
        {
            switch (Char.ToLower(c))
            {

                case 'b':
                case 'p':
                case 'f':
                case 'v': return '1';

                case 'c':
                case 's':
                case 'k':
                case 'g':
                case 'j':
                case 'q':
                case 'x':
                case 'z': return '2';

                case 'd':
                case 't': return '3';

                case 'l': return '4';

                case 'm':
                case 'n': return '5';

                case 'r': return '6';
            }
            return '*';
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> an array with the encoding of the word.
        /// This is never <code>null</code>.
        /// </returns>
        public override string[] BuildKeys(string word)
        {
            return !string.IsNullOrEmpty(word) ? new [] { BuildKey(word) } : EmptyKeys;
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> the encoding of the word. This is never <code>null</code>.
        /// </returns>
        public override string BuildKey(string word)
        {
            if (_length <= 0)
                return "";

            if (string.IsNullOrEmpty(word))
                return "";

            char[] chars = word.ToCharArray();
            System.Text.StringBuilder result = new System.Text.StringBuilder(_length);

            int inIdx, outIdx;
            char prevDigit;
            if (_full)
            {
                inIdx = outIdx = 0;
                prevDigit = '*';
            }
            else
            {
                inIdx = outIdx = 1;
                result.Append(Char.ToUpper(chars[0]));
                prevDigit = GETCode(chars[0]);
            }

            while (inIdx < chars.Length && outIdx < _length)
            {
                char c = GETCode(chars[inIdx]);

                if (c != '*' && c != prevDigit)
                {
                    result.Append(c);
                    outIdx++;
                }

                prevDigit = c;
                inIdx++;
            }

            for (; outIdx < _length; outIdx++)
                result.Append('0');

            return result.ToString();
        }
    }
}
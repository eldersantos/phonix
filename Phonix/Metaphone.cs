using System.Text;
using Phonix.Similarity;

namespace Phonix
{

    /// <summary> Encoder implementing the phonetic algorithm "Metaphone".
    /// Metaphone was originally developed by Lawrence Philips.
    /// This implementation is based on his original BASIC implementation.
    /// 
    /// </summary>
    /// <seealso cref="Soundex">
    /// </seealso>
    /// <seealso cref="DoubleMetaphone">
    /// </seealso>
    public sealed class Metaphone : MetaphoneEncoder, ISimilarity
    {
// ReSharper disable InconsistentNaming
        private static readonly string[] GN_KN_PN_WR_AE = new [] { "GN", "KN", "PN", "WR", "AE" };

        private static readonly string[] WH = new [] { "WH" };
        private static readonly string[] IA = new [] { "IA" };
        private static readonly string[] SCE_SCI_SCY = new [] { "SCE", "SCI", "SCY" };
        private static readonly string[] E_I_Y = new [] { "E", "I", "Y" };
        private static readonly string[] SCH = new [] { "SCH" };
        private static readonly string[] GE_GI_GY = new [] { "GE", "GI", "GY" };
        private static readonly string[] NED = new [] { "NED" };
        private static readonly string[] DGE_DGI_DGY = new [] { "DGE", "DGI", "DGY" };
        private static readonly string[] C_S_P_T_G = new [] { "C", "S", "P", "T", "G" };
        private static readonly string[] IO_IA = new [] { "IO", "IA" };
        private static readonly string[] CH = new [] { "CH" };
// ReSharper restore InconsistentNaming

        /// <summary> Constructs a Metaphone encoder which generates keys of given
        /// maximal length.
        /// </summary>
        /// <param name="maxLength">the maximal length of the generated keys. If negative,
        /// the lengths of the keys returned are only limited
        /// by the lengths of the words to encode.
        /// </param>
        public Metaphone(int maxLength) : base(maxLength)
        {
        }

        /// <summary> Constructs a Metaphone encoder which generates keys with
        /// maximal length 4.
        /// </summary>
        public Metaphone(): base(4) {}

        /// <summary> Returns a <tt>String</tt> identifying the algorithm.</summary>
        public override string ToString()
        {
            return "Metaphone_" + MaxLength;
        }

        public bool IsSimilar(string[] words)
        {
            string[] encoders = new string[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                encoders[i] = GenerateKey(words[i]);
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

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> an array with the encoding of the word.
        /// This is never <code>null</code>.
        /// </returns>
        public override string[] GenerateKeys(string word)
        {
            return !string.IsNullOrEmpty(word) ? new[] { GenerateKey(word) } : EmptyKeys;
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> the encoding of the word. This is never <code>null</code>.
        /// </returns>
        public override string GenerateKey(string word)
        {
            if (string.IsNullOrEmpty(word))
                return "";

            StringBuilder buffer = new StringBuilder(word.Length);

            word = word.ToUpper();

            if (Match(word, 0, GN_KN_PN_WR_AE))
                word = word.Substring(1);

            if (Match(word, 0, 'X'))
                word = "S" + word.Substring(1);

            if (Match(word, 0, WH))
                word = "W" + word.Substring(2);

            int length = word.Length;
            int last = length - 1;

            for (int n = 0; n < length && (MaxLength < 0 || (buffer.Length < MaxLength)); n++)
            {
                char c = word[n];
                if (c != 'C' && n > 0 && Match(word, n - 1, c))
                    continue;

                switch (c)
                {

                    case 'A':
                        if (n == 0)
                            buffer.Append('A');
                        break;


                    case 'B':
                        if ((n != last) || !Match(word, n - 1, 'M'))
                            buffer.Append('B');
                        break;


                    case 'C':
                        if (!Match(word, n - 1, SCE_SCI_SCY))
                        {
                            if (Match(word, n + 1, IA))
                                buffer.Append('X');
                            else if (Match(word, n + 1, E_I_Y))
                                buffer.Append('S');
                            else if (Match(word, n - 1, SCH))
                                buffer.Append('K');
                            else if (Match(word, n + 1, 'H'))
                                buffer.Append((n == 0 && !IsVowel(word, n + 2)) ? 'K' : 'X');
                            else
                                buffer.Append('K');
                        }
                        break;


                    case 'D':
                        buffer.Append(Match(word, n + 1, GE_GI_GY) ? 'J' : 'T');
                        break;


                    case 'E':
                        if (n == 0)
                            buffer.Append('E');
                        break;


                    case 'F':
                        buffer.Append('F');
                        break;


                    case 'G':
                        bool silent = Match(word, n + 1, 'H') && !IsVowel(word, n + 2);

                        if (n > 0)
                        {
                            if ((n + 1 == last && Match(word, n + 1, 'N')) || (n + 3 == last && Match(word, n + 1, NED)))
                                // -GNED
                                silent = true;

                            if (Match(word, n - 1, DGE_DGI_DGY))
                                // -DGE- -DGI- -DGY-
                                silent = true;
                        }

                        if (!silent)
                            buffer.Append((Match(word, n + 1, E_I_Y) && !Match(word, n - 1, 'G')) ? 'J' : 'K');
                        break;


                    case 'H':
                        if (n < last && !Match(word, n - 1, C_S_P_T_G) && IsVowel(word, n + 1))
                            buffer.Append('H');
                        break;


                    case 'I':
                        if (n == 0)
                            buffer.Append('I');
                        break;


                    case 'J':
                        buffer.Append('J');
                        break;


                    case 'K':
                        if ((n == 0) || !Match(word, n - 1, 'C'))
                            buffer.Append('K');
                        break;


                    case 'L':
                        buffer.Append('L');
                        break;


                    case 'M':
                        buffer.Append('M');
                        break;


                    case 'N':
                        buffer.Append('N');
                        break;


                    case 'O':
                        if (n == 0)
                            buffer.Append('O');
                        break;


                    case 'P':
                        buffer.Append(Match(word, n + 1, 'H') ? 'F' : 'P');
                        break;


                    case 'Q':
                        buffer.Append('K');
                        break;


                    case 'R':
                        buffer.Append('R');
                        break;


                    case 'S':
                        if (Match(word, n + 1, IO_IA))
                            buffer.Append('X');
                        else
                            buffer.Append(Match(word, n + 1, 'H') ? 'X' : 'S');
                        break;


                    case 'T':
                        if (Match(word, n + 1, IO_IA))
                            buffer.Append('X');
                        else if (Match(word, n + 1, 'H'))
                        {
                            if (!Match(word, n - 1, 'T'))
                                buffer.Append('0');
                        }
                        else
                        {
                            if (!Match(word, n + 1, CH))
                                buffer.Append('T');
                        }
                        break;


                    case 'U':
                        if (n == 0)
                            buffer.Append('U');
                        break;


                    case 'V':
                        buffer.Append('F');
                        break;


                    case 'W':
                        if (IsVowel(word, n + 1))
                            buffer.Append('W');
                        break;


                    case 'X':
                        buffer.Append("KS");
                        break;


                    case 'Y':
                        if (IsVowel(word, n + 1))
                            buffer.Append('Y');
                        break;


                    case 'Z':
                        buffer.Append('S');
                        break;
                }
            }

            if (MaxLength < 0)
            {
                return buffer.ToString();
            }
            // limit the length of the resulting strings
            int bufferLength = System.Math.Min(MaxLength, buffer.Length);
            return buffer.ToString().Substring(0, (bufferLength) - (0));
        }
    }
}
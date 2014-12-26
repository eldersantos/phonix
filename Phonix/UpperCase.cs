using System.Globalization;

namespace Phonix
{
    /// <summary> Encoder implementing upper-case copy of given words. Therefore
    /// no phonetic encoding takes place here.
    /// 
    /// </summary>
    /// <seealso cref="LowerCase">
    /// </seealso>
    /// <seealso cref="Exact">
    /// </seealso>
    public sealed class UpperCase : PhoneticEncoder
    {
        private readonly CultureInfo _locale;

        /// <summary> Constructs an upper-case copier with locale.</summary>
        /// <param name="locale">the locale to use while generating upper-case characters.
        /// </param>
        public UpperCase(CultureInfo locale)
        {
            _locale = locale;
        }

        /// <summary> Constructs an upper-case copier without locale.</summary>
        public UpperCase()
        {
            _locale = null;
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> an array with the encoding of the word.
        /// This is never <code>null</code>.
        /// </returns>
        public override string[] GenerateKeys(string word)
        {
            if (_locale != null)
                return !string.IsNullOrEmpty(word) ? new [] { word.ToLower(_locale).ToUpper(_locale) } : EmptyKeys;
            return !string.IsNullOrEmpty(word) ? new [] { word.ToLower().ToUpper() } : EmptyKeys;
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> the encoding of the word. This is never <code>null</code>.
        /// </returns>
        public override string GenerateKey(string word)
        {
            if (_locale != null)
                return !string.IsNullOrEmpty(word) ? word.ToLower(_locale).ToUpper(_locale) : "";
            return !string.IsNullOrEmpty(word) ? word.ToLower().ToUpper() : "";
        }

        /// <summary> Returns a <tt>String</tt> identifying the algorithm.</summary>
        public override string ToString()
        {
            return "UpperCase";
        }

    }
}
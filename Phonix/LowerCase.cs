using System.Globalization;
namespace Phonix
{
    /// <summary> Encoder implementing lower-case copy of given words. Therefore
    /// no phonetic encoding takes place here.
    /// 
    /// </summary>
    /// <seealso cref="UpperCase">
    /// </seealso>
    /// <seealso cref="Exact">
    /// </seealso>
    public sealed class LowerCase : PhoneticEncoder
    {
        private readonly CultureInfo _locale;

        /// <summary> Constructs a lower-case copier with locale.</summary>
        /// <param name="locale">the locale to use while generating lower-case characters.
        /// </param>
        public LowerCase(CultureInfo locale)
        {
            _locale = locale;
        }

        /// <summary> Constructs a lower-case copier without locale.</summary>
        public LowerCase()
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
                return !string.IsNullOrEmpty(word) ? new[] { word.ToUpper(_locale).ToLower(_locale) } : EmptyKeys;
            return !string.IsNullOrEmpty(word) ? new[] { word.ToUpper().ToLower() } : EmptyKeys;
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> the encoding of the word. This is never <code>null</code>.
        /// </returns>
        public override string GenerateKey(string word)
        {
            if (_locale != null)
                return !string.IsNullOrEmpty(word) ? word.ToUpper(_locale).ToLower(_locale) : "";
            return !string.IsNullOrEmpty(word) ? word.ToUpper().ToLower() : "";
        }

        /// <summary> Returns a <tt>String</tt> identifying the algorithm.</summary>
        public override string ToString()
        {
            return "LowerCase";
        }

    }
}
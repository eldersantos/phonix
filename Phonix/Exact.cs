namespace Phonix
{

    /// <summary> Encoder implementing exact copy of given words. Therefore
    /// no phonetic encoding takes place here.
    /// 
    /// </summary>
    /// <seealso cref="LowerCase">
    /// </seealso>
    /// <seealso cref="UpperCase">
    /// </seealso>
    public sealed class Exact : PhoneticEncoder
    {

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> an array with the encoding of the word.
        /// This is never <code>null</code>.
        /// </returns>
        public override string[] GenerateKeys(string word)
        {
            return !string.IsNullOrEmpty(word) ? new[] { word } : EmptyKeys;
        }

        /// <summary> Returns the encoding of the given word.</summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> the encoding of the word. This is never <code>null</code>.
        /// </returns>
        public override string GenerateKey(string word)
        {
            return !string.IsNullOrEmpty(word) ? word : "";
        }

        /// <summary> Returns a <tt>String</tt> identifying the algorithm.</summary>
        public override string ToString()
        {
            return "Exact";
        }

    }
}
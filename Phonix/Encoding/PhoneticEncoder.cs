namespace Phonix.Encoding
{

    /// <summary> <code>PhoneticEncoder</code>s generate one or more keys for a given word
    /// using a phonetic algorithm. The goal of each phonetic algorithm is to
    /// generate the same keys for words which have a similar pronunciation.
    /// 
    /// </summary>
    public abstract class PhoneticEncoder
    {
        /// <summary> Generates an array of keys.
        /// 
        /// </summary>
        /// <param name="word">the word for which the keys have to be generated.
        /// </param>
        /// <returns> an array of keys. The keys of more importance are found
        /// at the smaller indices, i.e. the most important key is found
        /// at index zero. The array is never <code>null</code>, but of length
        /// zero, if the given word is <code>null</code> or the empty-string.
        /// </returns>
        public abstract string[] BuildKeys(string word);

        /// <summary> Generates a key. If the underlying algorithm creates more
        /// than one key, the default key, i.e. the most important key, is returned.
        /// 
        /// </summary>
        /// <param name="word">the word for which the key has to be generated.
        /// </param>
        /// <returns> a key. The result is never <code>null</code>, i.e. if
        /// the given word is <code>null</code> or the empty-string,
        /// then the empty-string is returned.
        /// </returns>
        public abstract string BuildKey(string word);

        public static readonly string[] EmptyKeys = new string[0];
    }
}
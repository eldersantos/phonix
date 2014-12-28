using System.Text.RegularExpressions;
using Phonix.Encoding;
using Phonix.Similarity;

namespace Phonix
{
    public sealed class CaverPhone : PhoneticEncoder, ISimilarity
    {
        static readonly Regex Alpha = new Regex("[^a-z]", RegexOptions.Compiled);
        static readonly Regex LowerVowel = new Regex("[aeiou]", RegexOptions.Compiled);

        private static string TranslateRemaining(string key)
        {
            int nameLength = key.Length;
            //Replace
            //cq with 2q
            key = key.Replace("cq", "2q");
            //ci with si
            key = key.Replace("ci", "si");
            //ce with se
            key = key.Replace("ce", "se");
            //cy with sy
            key = key.Replace("cy", "sy");
            //tch with 2ch
            key = key.Replace("tch", "2ch");
            //c with k
            key = key.Replace("c", "k");
            //q with k
            key = key.Replace("q", "k");
            //x with k
            key = key.Replace("x", "k");
            //v with f
            key = key.Replace("v", "f");
            //dg with 2g
            key = key.Replace("dg", "2g");
            //tio with sio
            key = key.Replace("tio", "sio");
            //tia with sia
            key = key.Replace("tia", "sia");
            //d with t
            key = key.Replace("d", "t");
            //ph with fh
            key = key.Replace("ph", "fh");
            //b with p
            key = key.Replace("b", "p");
            //sh with s2
            key = key.Replace("sh", "s2");
            //z with s
            key = key.Replace("z", "s");
            //any initial vowel with an A
            if (LowerVowel.IsMatch(key.Substring(0, 1)))
            {
                key = "A" + key.Substring(1 < nameLength ? 1 : nameLength);
            }
            //all other vowels with a 3
            key = LowerVowel.Replace(key, "3");

            //the next 2 were moved up for the revised caverphone in 2004

            //j with y
            key = key.Replace("j", "y");

            //revised in 2004 to only affect the INITIAL y3.
            //y3 with Y3
            //key = key.Replace("y3", "Y3");
            if (key.Substring(0, 2) == "y3")
            {
                key = "Y3" + key.Substring(2 < nameLength ? 2 : nameLength);
            }

            //this was new in revised 2004
            //any initial y with an A
            if (key.Substring(0, 1) == "y")
            {
                key = "A" + key.Substring(1 < nameLength ? 1 : nameLength);
            }

            //the next one was revised in revised 2004 caverphone to y->3
            ////y with 2
            key = key.Replace("y", "3");

            //3gh3 with 3kh3
            key = key.Replace("3gh3", "3kh3");
            //gh with 22
            key = key.Replace("gh", "22");
            //g with k
            key = key.Replace("g", "k");
            //groups of the letter s with a S
            key = Regex.Replace(key, "[s]{1,}", "S");
            //groups of the letter t with a T
            key = Regex.Replace(key, "[t]{1,}", "T");
            //groups of the letter p with a P
            key = Regex.Replace(key, "[p]{1,}", "P");
            //groups of the letter k with a K
            key = Regex.Replace(key, "[k]{1,}", "K");
            //groups of the letter f with a F
            key = Regex.Replace(key, "[f]{1,}", "F");
            //groups of the letter m with a M
            key = Regex.Replace(key, "[m]{1,}", "M");
            //groups of the letter n with a N
            key = Regex.Replace(key, "[n]{1,}", "N");
            //w3 with W3
            key = key.Replace("w3", "W3");
            //wh3 with Wh3
            key = key.Replace("wh3", "Wh3");

            //next 2 were removed in the revised caverphone in 2004
            ////wy with Wy
            //key = key.Replace("wy", "Wy");
            ////why with Why
            //key = key.Replace("why", "Why");


            //this was new in revised 2004
            //if the name ends in w replace the final w with 3
            if (key.EndsWith("w"))
            {
                key = key.Substring(0, key.Length - 1) + "3";
            }

            //w with 2
            key = key.Replace("w", "2");
            //any initial h with an A
            if (key.Substring(0, 1) == "h")
            {
                key = "A" + key.Substring(1 < nameLength ? 1 : nameLength);
            }
            //all other occurrences of h with a 2
            key = key.Replace("h", "2");
            //r3 with R3
            key = key.Replace("r3", "R3");


            //this was new in revised 2004
            //if the name ends in r replace the replace final r with 3
            if (key.EndsWith("r"))
            {
                key = key.Substring(0, key.Length - 1) + "3";
            }

            //The next one was removed in revised 2004 caverphone
            ////ry with Ry
            //key = key.Replace("ry", "Ry");

            //r with 2
            key = key.Replace("r", "2");
            //l3 with L3
            key = key.Replace("l3", "L3");


            //this was new in revised 2004
            //if the name ends in r replace the replace final r with 3
            if (key.EndsWith("l"))
            {
                key = key.Substring(0, key.Length - 1) + "3";
            }

            //The next one was removed in revised 2004 caverphone
            ////ly with Ly
            //key = key.Replace("ly", "Ly");


            //l with 2
            key = key.Replace("l", "2");


            //remove all
            //2s
            key = key.Replace("2", string.Empty);

            //this was new in revised 2004
            //if the name ends in 3 replace the replace final 3 with A
            if (key.EndsWith("3"))
            {
                key = key.Substring(0, key.Length - 1) + "A";
            }

            //remove all
            //3s
            key = key.Replace("3", string.Empty);

            return key;
        }

        private static string TranslateStartsWith(string name)
        {
            //If the name starts with
            //cough make it cou2f
            //rough make it rou2f
            //tough make it tou2f
            //enough make it enou2f
            //If the name starts with trough make it trou2f
            //gn make it 2n
            //mb make it m2
            int nameLength = name.Length;

            if (name.StartsWith("cough"))
            {
                name = "cou2f" + name.Substring(5 < nameLength ? 5 : nameLength);
            }
            else if (name.StartsWith("rough"))
            {
                name = "rou2f" + name.Substring(5 < nameLength ? 5 : nameLength);
            }
            else if (name.StartsWith("tough"))
            {
                name = "tou2f" + name.Substring(5 < nameLength ? 5 : nameLength);
            }
            else if (name.StartsWith("trough")) //this was new in revised 2004
            {
                name = "trou2f" + name.Substring(6 < nameLength ? 6 : nameLength);
            }
            else if (name.StartsWith("enough"))
            {
                name = "enou2f" + name.Substring(6 < nameLength ? 6 : nameLength);
            }
            else if (name.StartsWith("gn"))
            {
                name = "2n" + name.Substring(2 < nameLength ? 2 : nameLength);
            }
            else if (name.StartsWith("mb"))
            {
                name = "m2" + name.Substring(2 < nameLength ? 2 : nameLength);
            }

            return name;
        }

        public override string[] BuildKeys(string word)
        {
            return !string.IsNullOrEmpty(word) ? new[] { BuildKey(word) } : EmptyKeys;
        }

        public override string BuildKey(string word)
        {
            if (string.IsNullOrEmpty(word)) { return string.Empty; }

            var key = word.ToLower();
            key = Alpha.Replace(key, string.Empty);

            if (key == string.Empty) { return string.Empty; }

            //this was new in revised 2004
            //remove ending e
            if (key.EndsWith("e"))
            {
                key = key.Substring(0, key.Length - 1);
            }

            key = TranslateStartsWith(key);
            key = TranslateRemaining(key);

            //append 10 "1"s at the end
            key = key + "1111111111";

            //in 2004 revised caverphone they changed from 6 to 10 characters
            //take the first 10 characters as the code
            return key.Substring(0, 10);
        }

        public bool IsSimilar(string[] words)
        {
            string[] encoders = new string[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                encoders[i] = BuildKey(words[i]);
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

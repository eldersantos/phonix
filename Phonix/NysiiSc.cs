using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Phonix
{
    /*
    * --1 Translate first characters of name: MAC → MCC, KN → N, K → C, PH → FF, PF → FF, SCH → SSS
       --2 Translate last characters of name: EE → Y, IE → Y, DT, RT, RD, NT, ND → D
       --3 First character of key = first character of name.
       4 Translate remaining characters by following rules, incrementing by one character each time:
       EV → AF else A, E, I, O, U → A
       Q → G, Z → S, M → N
       KN → N else K → C
       SCH → SSS, PH → FF
       H → If previous or next is nonvowel, previous.
       W → If previous is vowel, previous.
       Add current to key if current is not same as the last key character.
      -- 6 If last character is S, remove it.
      -- 7 If last characters are AY, replace with Y.
      -- 8 If last character is A, remove it.
    * */
    internal static class NysiiSc
    {

        public static void GenerateNysiisKey(string name, out string key, out string fullKey)
        {
            key = string.Empty;
            fullKey = string.Empty;
            if (string.IsNullOrEmpty(name)) { return; }

            string upperName = name.ToUpper();

            //Let's strip non A-Z characters
            upperName = Regex.Replace(upperName, "[^A-Z]", string.Empty, RegexOptions.Compiled);

            //step 1
            TranslateFirstCharacters(ref upperName);
            //step 2
            TranslateLastCharacters(ref upperName);

            //step 3
            string firstCharacter = upperName.Substring(0, 1);
            string remainingName = upperName.Length > 1 ? upperName.Substring(1) : string.Empty;
            if (!string.IsNullOrEmpty(remainingName.Trim()))
            {
                //step 4
                TranslateRemaining(ref remainingName);

                //step 6 - 8
                ReplaceLastCharacter(ref remainingName);
            }
            //collapse repeating characters and append first character back on
            fullKey = firstCharacter + SioHelpers.CollapseAdjacentRepeating(remainingName);

            //a true NYSIIS key is only 6 characters long
            key = fullKey.Substring(0, (fullKey.Length >= 6 ? 6 : fullKey.Length));
        }



        private static void TranslateRemaining(ref string remainingName)
        {
            if (remainingName.Length == 0) { return; }
            //- 4 Translate remaining characters by following rules, incrementing by one character each time:
            //- EV → AF else A, E, I, O, U → A
            //- Q → G, Z → S, M → N
            //- KN → N else K → C
            //- SCH → SSS, PH → FF
            //H → If previous or next is nonvowel, previous.
            //W → If previous is vowel, previous.
            //Add current to key if current is not same as the last key character.

            remainingName = remainingName.Replace("EV", "AF");
            remainingName = SioHelpers.Vowels.Replace(remainingName, "A");

            remainingName = remainingName.Replace("Q", "G");
            remainingName = remainingName.Replace("Z", "S");
            remainingName = remainingName.Replace("M", "N");

            remainingName = remainingName.Replace("KN", "N");
            remainingName = remainingName.Replace("K", "C");

            remainingName = remainingName.Replace("SCH", "SSS");
            remainingName = remainingName.Replace("PH", "FF");

            remainingName = HPreNon.Replace(remainingName, delegate(Match match)
            {
                string v = match.ToString();
                return v.Substring(0, 1);
            });

            remainingName = HSufNon.Replace(remainingName, delegate(Match match)
            {
                string v = match.ToString();
                return v.Substring(0, 1);
            });


            remainingName = WPreNon.Replace(remainingName, "A");
        }

        private static readonly Regex HPreNon = new Regex("[^AEIOU]H");
        private static readonly Regex HSufNon = new Regex(".H[^AEIOU]");
        private static readonly Regex WPreNon = new Regex("[AEIOU]W");

        private static void ReplaceLastCharacter(ref string remainingName)
        {
            //6 If last character is S, remove it.
            //7 If last characters are AY, replace with Y.
            //8 If last character is A, remove it.
            if (remainingName.Length == 0) { return; }

            if (remainingName.EndsWith("S"))
            {
                remainingName = remainingName.Length > 0 ? remainingName.Substring(0, remainingName.Length - 1) : string.Empty;
            }
            else if (remainingName.EndsWith("AY"))
            {
                remainingName = remainingName.Length > 0 ? remainingName.Substring(0, remainingName.Length - 2) : string.Empty;
                remainingName += "Y";
            }
            else if (remainingName.EndsWith("A"))
            {
                remainingName = remainingName.Length > 0 ? remainingName.Substring(0, remainingName.Length - 1) : string.Empty;
            }
        }

        private static void TranslateFirstCharacters(ref string name)
        {
            //Translate first characters of name: MAC → MCC, KN → N, K → C, PH → FF, PF → FF, SCH → SSS
            int nameLength = name.Length;

            if (name.StartsWith("MAC"))
            {
                name = "MCC" + name.Substring(3 < nameLength ? 3 : nameLength);
            }
            else if (name.StartsWith("KN"))
            {
                name = "N" + name.Substring(2 < nameLength ? 2 : nameLength);
            }
            else if (name.StartsWith("K"))
            {
                name = "C" + name.Substring(1 < nameLength ? 1 : nameLength);
            }
            else if (name.StartsWith("PH"))
            {
                name = "FF" + name.Substring(2 < nameLength ? 2 : nameLength);
            }
            else if (name.StartsWith("PF"))
            {
                name = "FF" + name.Substring(2 < nameLength ? 2 : nameLength);
            }
            else if (name.StartsWith("SCH"))
            {
                name = "SSS" + name.Substring(3 < nameLength ? 3 : nameLength);
            }
        }

        private static void TranslateLastCharacters(ref string name)
        {
            //Translate last characters of name: EE → Y, IE → Y, DT, RT, RD, NT, ND → D
            if (name.EndsWith("EE") || name.EndsWith("IE"))
            {
                name = name.Substring(0, name.Length - 2) + "Y";
            }
            else if (name.EndsWith("DT") || name.EndsWith("RT") || name.EndsWith("RD") || name.EndsWith("NT") || name.EndsWith("ND"))
            {
                name = name.Substring(0, name.Length - 2) + "D";
            }
        }

    }
}

using System;
using Phonix.Similarity;

namespace Phonix
{
    public sealed class DoubleMetaphone : MetaphoneEncoder, ISimilarity
    {
// ReSharper disable InconsistentNaming
        private static readonly string[] GN_KN_PN_WR_PS = new [] { "GN", "KN", "PN", "WR", "PS" };
        private static readonly string[] ACH = new[] { "ACH" };
        private static readonly string[] BACHER_MACHER = new[] { "BACHER", "MACHER" };
        private static readonly string[] CAESAR = new[] { "CAESAR" };
        private static readonly string[] CHIA = new[] { "CHIA" };
        private static readonly string[] CH = new[] { "CH" };
        private static readonly string[] CHAE = new[] { "CHAE" };
        private static readonly string[] HARAC_HARIS_HOR_HYM_HIA_HEM = new[] { "HARAC", "HARIS", "HOR", "HYM", "HIA", "HEM" };
        private static readonly string[] CHORE = new[] { "CHORE" };
        private static readonly string[] SCH = new[] { "SCH" };
        private static readonly string[] VAN__VON__SCH = new[] { "VAN ", "VON ", "SCH" };
        private static readonly string[] ORCHES_ARCHIT_ORCHID = new[] { "ORCHES", "ARCHIT", "ORCHID" };
        private static readonly string[] T_S = new[] { "T", "S" };
        private static readonly string[] A_O = new[] { "A", "O" };
        private static readonly string[] A_O_U_E = new[] { "A", "O", "U", "E" };
        private static readonly string[] L_R_N_M_B_H_F_V_W__ = new[] { "L", "R", "N", "M", "B", "H", "F", "V", "W", " " };
        private static readonly string[] MC = new[] { "MC" };
        private static readonly string[] CZ = new[] { "CZ" };
        private static readonly string[] WICZ = new[] { "WICZ" };
        private static readonly string[] CIA = new[] { "CIA" };
        private static readonly string[] CC = new[] { "CC" };
        private static readonly string[] I_E_H = new[] { "I", "E", "H" };
        private static readonly string[] HU = new[] { "HU" };
        private static readonly string[] UCCEE_UCCES = new[] { "UCCEE", "UCCES" };
        private static readonly string[] CK_CG_CQ = new[] { "CK", "CG", "CQ" };
        private static readonly string[] CI_CE_CY = new[] { "CI", "CE", "CY" };
        private static readonly string[] CIO_CIE_CIA = new[] { "CIO", "CIE", "CIA" };
        private static readonly string[] _C__Q__G = new[] { " C", " Q", " G" };
        private static readonly string[] C_K_Q = new[] { "C", "K", "Q" };
        private static readonly string[] CE_CI = new[] { "CE", "CI" };
        private static readonly string[] DG = new[] { "DG" };
        private static readonly string[] I_E_Y = new[] { "I", "E", "Y" };
        private static readonly string[] DT_DD = new[] { "DT", "DD" };
        private static readonly string[] B_H_D = new[] { "B", "H", "D" };
        private static readonly string[] B_H = new[] { "B", "H" };
        private static readonly string[] C_G_L_R_T = new[] { "C", "G", "L", "R", "T" };
        private static readonly string[] EY = new[] { "EY" };
        private static readonly string[] LI = new[] { "LI" };
        private static readonly string[] Y_ES_EP_EB_EL_EY_IB_IL_IN_IE_EI_ER = new[] { "Y", "ES", "EP", "EB", "EL", "EY", "IB", "IL", "IN", "IE", "EI", "ER" };
        private static readonly string[] Y_ER = new[] { "Y", "ER" };
        private static readonly string[] DANGER_RANGER_MANGER = new[] { "DANGER", "RANGER", "MANGER" };
        private static readonly string[] E_I = new[] { "E", "I" };
        private static readonly string[] RGY_OGY = new[] { "RGY", "OGY" };
        private static readonly string[] E_I_Y = new[] { "E", "I", "Y" };
        private static readonly string[] AGGI_OGGI = new[] { "AGGI", "OGGI" };
        private static readonly string[] ET = new[] { "ET" };
/*
        private static readonly string[] IER_ = new[] { "IER " };
*/
        private static readonly string[] JOSE = new[] { "JOSE" };
        private static readonly string[] SAN_ = new[] { "SAN " };
        private static readonly string[] L_T_K_S_N_M_B_Z = new[] { "L", "T", "K", "S", "N", "M", "B", "Z" };
        private static readonly string[] S_K_L = new[] { "S", "K", "L" };
        private static readonly string[] ILLO_ILLA_ALLE = new[] { "ILLO", "ILLA", "ALLE" };
        private static readonly string[] AS_OS = new[] { "AS", "OS" };
        private static readonly string[] ALLE = new[] { "ALLE" };
        private static readonly string[] UMB = new[] { "UMB" };
        private static readonly string[] P_B = new[] { "P", "B" };
        private static readonly string[] IE = new[] { "IE" };
        private static readonly string[] IER = new[] { "IER" };
        private static readonly string[] ER = new[] { "ER" };
        private static readonly string[] ME_MA = new[] { "ME", "MA" };
        private static readonly string[] ISL_YSL = new[] { "ISL", "YSL" };
        private static readonly string[] SUGAR = new[] { "SUGAR" };
        private static readonly string[] SH = new[] { "SH" };
        private static readonly string[] HEIM_HOEK_HOLM_HOLZ = new[] { "HEIM", "HOEK", "HOLM", "HOLZ" };
        private static readonly string[] SIO_SIA = new[] { "SIO", "SIA" };
        private static readonly string[] SIAN = new[] { "SIAN" };
        private static readonly string[] M_N_L_W = new[] { "M", "N", "L", "W" };
/*
        private static readonly string[] Z = new[] { "Z" };
*/
        private static readonly string[] SC = new[] { "SC" };
        private static readonly string[] OO_ER_EN_UY_ED_EM = new [] { "OO", "ER", "EN", "UY", "ED", "EM" };
        private static readonly string[] ER_EN = new [] { "ER", "EN" };
        private static readonly string[] AI_OI = new [] { "AI", "OI" };
        private static readonly string[] S_Z = new [] { "S", "Z" };
        private static readonly string[] TION = new [] { "TION" };
        private static readonly string[] TIA_TCH = new [] { "TIA", "TCH" };
        private static readonly string[] TH_TTH = new [] { "TH", "TTH" };
        private static readonly string[] OM_AM = new [] { "OM", "AM" };
        private static readonly string[] T_D = new [] { "T", "D" };
        private static readonly string[] WR = new [] { "WR" };
        private static readonly string[] WH = new [] { "WH" };
        private static readonly string[] EWSKI_EWSKY_OWSKI_OWSKY = new [] { "EWSKI", "EWSKY", "OWSKI", "OWSKY" };
        private static readonly string[] WICZ_WITZ = new [] { "WICZ", "WITZ" };
        private static readonly string[] IAU_EAU = new [] { "IAU", "EAU" };
        private static readonly string[] AU_OU = new [] { "AU", "OU" };
        private static readonly string[] C_X = new [] { "C", "X" };
        private static readonly string[] ZO_ZI_ZA = new [] { "ZO", "ZI", "ZA" };
// ReSharper restore InconsistentNaming

        private System.Text.StringBuilder _primaryBuffer;
        private System.Text.StringBuilder _secondaryBuffer;
        private bool _hasAlternate;

        /// <summary> Constructs a DoubleMetaphone encoder which generates keys of given
        /// maximal length.
        /// </summary>
        /// <param name="maxLength">the maximal length of the generated keys. If negative,
        /// the lengths of the keys returned are only limited
        /// by the lengths of the words to encode.
        /// </param>
        public DoubleMetaphone(int maxLength) : base(maxLength)
        {
        }

        /// <summary> Constructs a DoubleMetaphone encoder which generates keys with
        /// maximal length 4.
        /// </summary>
        public DoubleMetaphone() : base(4)
        {
        }

        /// <summary> Returns a <tt>String</tt> identifying the algorithm.</summary>
        public override string ToString()
        {
            return "DoubleMetaphone_" + MaxLength;
        }

        public bool IsSimilar(string[] words)
        {
            var encoders = new string[words.Length];

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

        private void Add(string main)
        {
            _primaryBuffer.Append(main);
            _secondaryBuffer.Append(main);
        }

        private void Add(string main, string alternate)
        {
            _primaryBuffer.Append(main);
            if (alternate.Length > 0)
            {
                _hasAlternate = true;
                if (!alternate.Equals(" "))
                {
                    _secondaryBuffer.Append(alternate);
                }
            }
            else
            {
                if (main.Length > 0 && !main.Equals(" "))
                {
                    _secondaryBuffer.Append(main);
                }
            }
        }

        private static bool IsSlavoGermanic(string stringRenamed)
        {
            return (stringRenamed.IndexOf('W') >= 0) || (stringRenamed.IndexOf('K') >= 0) || (stringRenamed.IndexOf("CZ", StringComparison.Ordinal) >= 0) || (stringRenamed.IndexOf("WITZ", StringComparison.Ordinal) >= 0);
        }

        /// <summary> Returns an encoding of the given word, that is based on the most
        /// commonly heard pronunciation of the word in the U.S.A.
        /// </summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> the encoding of the word. This is never <code>null</code>.
        /// </returns>
        public override string BuildKey(string word)
        {
            var result = BuildKeys(word);
            return (result.Length > 0) ? result[0] : "";
        }

        /// <summary> Returns the encodings of the given word. The first is based on the most
        /// commonly heard pronunciation of the word in the U.S.A.
        /// </summary>
        /// <param name="word">the word to encode.
        /// </param>
        /// <returns> an array of the encodings of the word.
        /// This is never <code>null</code>.
        /// </returns>
        public override string[] BuildKeys(string word)
        {
            lock (this)
            {
                if (string.IsNullOrEmpty(word))
                {
                    return EmptyKeys;
                }

                _primaryBuffer = new System.Text.StringBuilder(word.Length);
                _secondaryBuffer = new System.Text.StringBuilder(word.Length);
                _hasAlternate = false;

                word = word.ToUpper();

                var length = word.Length;
                var last = length - 1;

                var isSlavoGermanic = IsSlavoGermanic(word);

                var n = 0;

                // skip these when at start of word
                if (Match(word, 0, GN_KN_PN_WR_PS))
                    n++;

                // initial 'X' is pronounced 'Z' e.g. 'Xavier'
                if (Match(word, 0, 'X'))
                {
                    Add("S"); //'Z' maps to 'S'
                    n++;
                }

                while (n < length && (MaxLength < 0 || (_primaryBuffer.Length < MaxLength && _secondaryBuffer.Length < MaxLength)))
                {
                    switch (word[n])
                    {

                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':
                        case 'Y':
                            if (n == 0)
                                //all init vowels now map to 'A'
                                Add("A");
                            n++;
                            break;
                        case 'B':
                            //"-mb", e.g", "dumb", already skipped over...
                            Add("P");
                            n += (Match(word, n + 1, 'B') ? 2 : 1);
                            break;
                        case 'Ç':
                            Add("S");
                            n++;
                            break;
                        case 'C':
                            // various germanic
                            if ((n > 1) && !IsVowel(word, n - 2) && Match(word, n - 1, ACH) && !Match(word, n + 2, 'I') && (!Match(word, n + 2, 'E') || Match(word, n - 2, BACHER_MACHER)))
                            {
                                Add("K");
                                n += 2;
                                break;
                            }

                            // special case 'caesar'
                            if ((n == 0) && Match(word, n, CAESAR))
                            {
                                Add("S");
                                n += 2;
                                break;
                            }

                            // italian 'chianti'
                            if (Match(word, n, CHIA))
                            {
                                Add("K");
                                n += 2;
                                break;
                            }

                            if (Match(word, n, CH))
                            {
                                // find 'michael'
                                if ((n > 0) && Match(word, n, CHAE))
                                {
                                    Add("K", "X");
                                    n += 2;
                                    break;
                                }

                                // greek roots e.g. 'chemistry', 'chorus'
                                if ((n == 0) && Match(word, n + 1, HARAC_HARIS_HOR_HYM_HIA_HEM) && !Match(word, 0, CHORE))
                                {
                                    Add("K");
                                    n += 2;
                                    break;
                                }

                                // germanic, greek, or otherwise 'ch' for 'kh' sound
                                if (Match(word, 0, VAN__VON__SCH) || Match(word, n - 2, ORCHES_ARCHIT_ORCHID) || Match(word, n + 2, T_S) || (((n == 0) || Match(word, n - 1, A_O_U_E)) && Match(word, n + 2, L_R_N_M_B_H_F_V_W__)))
                                {
                                    Add("K");
                                }
                                else
                                {
                                    if (n > 0)
                                    {
                                        if (Match(word, 0, MC))
                                            // e.g., "McHugh"
                                            Add("K");
                                        else
                                            Add("X", "K");
                                    }
                                    else
                                        Add("X");
                                }
                                n += 2;
                                break;
                            }

                            // e.g., 'czerny'
                            if (Match(word, n, CZ) && !Match(word, n - 2, WICZ))
                            {
                                Add("S", "X");
                                n += 2;
                                break;
                            }

                            // e.g., 'focaccia'
                            if (Match(word, n + 1, CIA))
                            {
                                Add("X");
                                n += 3;
                                break;
                            }

                            // double 'C', but not if e.g. 'McClellan'
                            if (Match(word, n, CC) && !((n == 1) && Match(word, 0, 'M')))
                            {
                                // 'bellocchio' but not 'bacchus'
                                if (Match(word, n + 2, I_E_H) && !Match(word, n + 2, HU))
                                {
                                    // 'accident', 'accede', 'succeed'
                                    if (((n == 1) && Match(word, n - 1, 'A')) || Match(word, n - 1, UCCEE_UCCES))
                                        Add("KS");
                                    // 'bacci', 'bertucci', other italian
                                    else
                                        Add("X");
                                    n += 3;
                                    break;
                                }
                                // Pierce's rule
                                Add("K");
                                n += 2;
                                break;
                            }

                            if (Match(word, n, CK_CG_CQ))
                            {
                                Add("K");
                                n += 2;
                                break;
                            }

                            if (Match(word, n, CI_CE_CY))
                            {
                                // italian vs. english
                                if (Match(word, n, CIO_CIE_CIA))
                                    Add("S", "X");
                                else
                                    Add("S");
                                n += 2;
                                break;
                            }

                            // else
                            Add("K");

                            // name sent in 'mac caffrey', 'mac gregor'
                            if (Match(word, n + 1, _C__Q__G))
                                n += 3;
                            else
                                n += ((Match(word, n + 1, C_K_Q) && !Match(word, n + 1, CE_CI)) ? 2 : 1);
                            break;
                        case 'D':
                            if (Match(word, n, DG))
                            {
                                if (Match(word, n + 2, I_E_Y))
                                {
                                    // e.g. 'edge'
                                    Add("J");
                                    n += 3;
                                    break;
                                }
                                // e.g. 'edgar'
                                Add("TK");
                                n += 2;
                                break;
                            }

                            if (Match(word, n, DT_DD))
                            {
                                Add("T");
                                n += 2;
                                break;
                            }

                            // else
                            Add("T");
                            n++;
                            break;
                        case 'F':
                            n += (Match(word, n + 1, 'F') ? 2 : 1);
                            Add("F");
                            break;
                        case 'G':
                            if (Match(word, n + 1, 'H'))
                            {
                                if ((n > 0) && !IsVowel(word, n - 1))
                                {
                                    Add("K");
                                    n += 2;
                                    break;
                                }

                                if (n < 3)
                                {
                                    // 'ghislane', 'ghiradelli'
                                    if (n == 0)
                                    {
                                        Add(Match(word, n + 2, 'I') ? "J" : "K");
                                        n += 2;
                                        break;
                                    }
                                }

                                // Parker's rule (with some further refinements) - e.g., 'hugh'
                                if (((n > 1) && Match(word, n - 2, B_H_D)) || ((n > 2) && Match(word, n - 3, B_H_D)) || ((n > 3) && Match(word, n - 4, B_H)))
                                {
                                    n += 2;
                                    break;
                                }
                                // e.g., 'laugh', 'McLaughlin', 'cough', 'gough', 'rough', 'tough'
                                if ((n > 2) && Match(word, n - 1, 'U') && Match(word, n - 3, C_G_L_R_T))
                                {
                                    Add("F");
                                }
                                else if ((n > 0) && !Match(word, n - 1, 'I'))
                                {
                                    Add("K");
                                }

                                n += 2;
                                break;
                            }

                            if (Match(word, n + 1, 'N'))
                            {
                                if ((n == 1) && IsVowel(word, 0) && !isSlavoGermanic)
                                {
                                    Add("KN", "N");
                                }
                                else
                                {
                                    // not e.g. 'cagney'
                                    if (!Match(word, n + 2, EY) && !Match(word, n + 1, 'Y') && !isSlavoGermanic)
                                    {
                                        Add("N", "KN");
                                    }
                                    else
                                    {
                                        Add("KN");
                                    }
                                }
                                n += 2;
                                break;
                            }

                            // 'tagliaro'
                            if (Match(word, n + 1, LI) && !isSlavoGermanic)
                            {
                                Add("KL", "L");
                                n += 2;
                                break;
                            }

                            // -ges-,-gep-,-gel-, -gie- at beginning
                            if ((n == 0) && Match(word, n + 1, Y_ES_EP_EB_EL_EY_IB_IL_IN_IE_EI_ER))
                            {
                                Add("K", "J");
                                n += 2;
                                break;
                            }

                            // -ger-,  -gy-
                            if (Match(word, n + 1, Y_ER) && !Match(word, 0, DANGER_RANGER_MANGER) && !Match(word, n - 1, E_I) && !Match(word, n - 1, RGY_OGY))
                            {
                                Add("K", "J");
                                n += 2;
                                break;
                            }

                            // italian e.g, 'biaggi'
                            if (Match(word, n + 1, E_I_Y) || Match(word, n - 1, AGGI_OGGI))
                            {
                                // obvious germanic
                                if (Match(word, 0, VAN__VON__SCH) || Match(word, n + 1, ET))
                                {
                                    Add("K");
                                }
                                else
                                {
                                    // always soft if french ending
                                    if (Match(word, n + 1, IER))
                                        Add("J");
                                    else
                                        Add("J", "K");
                                }
                                n += 2;
                                break;
                            }

                            Add("K");
                            n += (Match(word, n + 1, 'G') ? 2 : 1);
                            break;
                        case 'H':
                            // only keep if first & before vowel or btw. 2 vowels
                            if (((n == 0) || IsVowel(word, n - 1)) && IsVowel(word, n + 1))
                            {
                                Add("H");
                                n += 2;
                            }
                            else
                            {
                                //also takes care of 'HH'
                                n++;
                            }
                            break;
                        case 'J':
                            // obvious spanish, 'jose', 'san jacinto'
                            if (Match(word, n, JOSE) || Match(word, 0, SAN_))
                            {
                                if (((n == 0) && Match(word, n + 4, ' ')) || Match(word, 0, SAN_))
                                {
                                    Add("H");
                                }
                                else
                                {
                                    Add("J", "H");
                                }
                                n++;
                                break;
                            }

                            if ((n == 0) && !Match(word, n, JOSE))
                            {
                                Add("J", "A"); //Yankelovich/Jankelowicz
                            }
                            else
                            {
                                // spanish pron. of e.g. 'bajador'
                                if (IsVowel(word, n - 1) && !isSlavoGermanic && Match(word, n + 1, A_O))
                                {
                                    Add("J", "H");
                                }
                                else
                                {
                                    if (n == last)
                                    {
                                        Add("J", " ");
                                    }
                                    else
                                    {
                                        if (!Match(word, n + 1, L_T_K_S_N_M_B_Z) && !Match(word, n - 1, S_K_L))
                                            Add("J");
                                    }
                                }
                            }

                            n += (Match(word, n + 1, 'J') ? 2 : 1);
                            break;
                        case 'K':
                            n += (Match(word, n + 1, 'K') ? 2 : 1);
                            Add("K");
                            break;
                        case 'L':
                            if (Match(word, n + 1, 'L'))
                            {
                                // spanish e.g. 'cabrillo', 'gallegos'
                                if (((n == length - 3) && Match(word, n - 1, ILLO_ILLA_ALLE)) || ((Match(word, last - 1, AS_OS) || Match(word, last, A_O)) && Match(word, n - 1, ALLE)))
                                {
                                    Add("L", " ");
                                    n += 2;
                                    break;
                                }
                                n += 2;
                            }
                            else
                            {
                                n++;
                            }
                            Add("L");
                            break;
                        case 'M':
                            if ((Match(word, n - 1, UMB) && ((n + 1 == last) || Match(word, n + 2, ER))) || Match(word, n + 1, 'M'))
                            {
                                n += 2;
                            }
                            else
                            {
                                n++;
                            }
                            Add("M");
                            break;
                        case 'N':
                            n += (Match(word, n + 1, 'N') ? 2 : 1);
                            Add("N");
                            break;
                        case 'Ñ':
                            n++;
                            Add("N");
                            break;
                        case 'P':
                            if (Match(word, n + 1, 'H'))
                            {
                                Add("F");
                                n += 2;
                                break;
                            }

                            // also account for "campbell", "raspberry"
                            n += (Match(word, n + 1, P_B) ? 2 : 1);
                            Add("P");
                            break;
                        case 'Q':
                            n += (Match(word, n + 1, 'Q') ? 2 : 1);
                            Add("K");
                            break;
                        case 'R':
                            // french e.g. 'rogier', but exclude 'hochmeier'
                            if ((n == last) && !isSlavoGermanic && Match(word, n - 2, IE) && !Match(word, n - 4, ME_MA))
                            {
                                Add("", "R");
                            }
                            else
                            {
                                Add("R");
                            }

                            n += (Match(word, n + 1, 'R') ? 2 : 1);
                            break;
                        case 'S':
                            // special cases 'island', 'isle', 'carlisle', 'carlysle'
                            if (Match(word, n - 1, ISL_YSL))
                            {
                                n++;
                                break;
                            }

                            // special case 'sugar-'
                            if ((n == 0) && Match(word, n, SUGAR))
                            {
                                Add("X", "S");
                                n++;
                                break;
                            }

                            if (Match(word, n, SH))
                            {
                                // germanic
                                Add(Match(word, n + 1, HEIM_HOEK_HOLM_HOLZ) ? "S" : "X");
                                n += 2;
                                break;
                            }

                            // italian & armenian
                            if (Match(word, n, SIO_SIA) || Match(word, n, SIAN))
                            {
                                if (!isSlavoGermanic)
                                    Add("S", "X");
                                else
                                    Add("S");
                                n += 3;
                                break;
                            }

                            // german & anglicisations, e.g. 'smith' match 'schmidt', 'snider' match 'schneider'
                            // also, -sz- in slavic language altho in hungarian it is pronounced 's'
                            if (((n == 0) && Match(word, n + 1, M_N_L_W)) || Match(word, n + 1, 'Z'))
                            {
                                Add("S", "X");
                                n += (Match(word, n + 1, 'Z') ? 2 : 1);
                                break;
                            }

                            if (Match(word, n, SC))
                            {
                                // Schlesinger's rule
                                if (Match(word, n + 2, 'H'))
                                {
                                    // dutch origin, e.g. 'school', 'schooner'
                                    if (Match(word, n + 3, OO_ER_EN_UY_ED_EM))
                                    {
                                        // 'schermerhorn', 'schenker'
                                        if (Match(word, n + 3, ER_EN))
                                            Add("X", "SK");
                                        else
                                            Add("SK");
                                        n += 3;
                                        break;
                                    }
                                    if ((n == 0) && !IsVowel(word, 3) && !Match(word, 3, 'W'))
                                        Add("X", "S");
                                    else
                                        Add("X");
                                    n += 3;
                                    break;
                                }

                                Add(Match(word, n + 2, I_E_Y) ? "S" : "SK");
                                n += 3;
                                break;
                            }

                            // french e.g. 'resnais', 'artois'
                            if ((n == last) && Match(word, n - 2, AI_OI))
                                Add("", "S");
                            else
                                Add("S");

                            n += (Match(word, n + 1, S_Z) ? 2 : 1);
                            break;
                        case 'T':
                            if (Match(word, n, TION))
                            {
                                Add("X");
                                n += 3;
                                break;
                            }

                            if (Match(word, n, TIA_TCH))
                            {
                                Add("X");
                                n += 3;
                                break;
                            }

                            if (Match(word, n, TH_TTH))
                            {
                                // special case 'thomas', 'thames' or germanic
                                if (Match(word, n + 2, OM_AM) || Match(word, 0, VAN__VON__SCH))
                                    Add("T");
                                else
                                    Add("0", "T");
                                n += 2;
                                break;
                            }

                            n += (Match(word, n + 1, T_D) ? 2 : 1);
                            Add("T");
                            break;
                        case 'V':
                            n += (Match(word, n + 1, 'V') ? 2 : 1);
                            Add("F");
                            break;
                        case 'W':
                            // can also be in middle of word
                            if (Match(word, n, WR))
                            {
                                Add("R");
                                n += 2;
                                break;
                            }

                            if ((n == 0) && (IsVowel(word, n + 1) || Match(word, n, WH)))
                            {
                                // Wasserman should match Vasserman
                                if (IsVowel(word, n + 1))
                                    Add("A", "F");
                                //need Uomo to match Womo
                                else
                                    Add("A");
                            }

                            // Arnow should match Arnoff
                            if (((n == last) && IsVowel(word, n - 1)) || Match(word, n - 1, EWSKI_EWSKY_OWSKI_OWSKY) || Match(word, 0, SCH))
                            {
                                Add("", "F");
                                n++;
                                break;
                            }

                            // polish e.g. 'filipowicz'
                            if (Match(word, n, WICZ_WITZ))
                            {
                                Add("TS", "FX");
                                n += 4;
                                break;
                            }

                            // else skip it
                            n++;
                            break;
                        case 'X':
                            // french e.g. breaux
                            if (!((n == last) && (Match(word, n - 3, IAU_EAU) || Match(word, n - 2, AU_OU))))
                                Add("KS");

                            n += (Match(word, n + 1, C_X) ? 2 : 1);
                            break;
                        case 'Z':
                            // chinese pinyin e.g. 'zhao'
                            if (Match(word, n + 1, 'H'))
                            {
                                Add("J");
                                n += 2;
                                break;
                            }
                            if (Match(word, n + 1, ZO_ZI_ZA) || (isSlavoGermanic && (n > 0) && !Match(word, n - 1, 'T')))
                            {
                                Add("S", "TS");
                            }
                            else
                                Add("S");

                            n += (Match(word, n + 1, 'Z') ? 2 : 1);
                            break;
                        default:
                            n++;
                            break;
                    }
                }

                if (MaxLength < 0)
                {
                    return _hasAlternate ? new[] { _primaryBuffer.ToString(), _secondaryBuffer.ToString() } : new[] { _primaryBuffer.ToString() };
                }
                // limit the length of the resulting strings
                var primaryLength = Math.Min(MaxLength, _primaryBuffer.Length);
                if (!_hasAlternate) return new[] {_primaryBuffer.ToString().Substring(0, (primaryLength) - (0))};
                var secondaryLength = Math.Min(MaxLength, _secondaryBuffer.Length);
                return new[] { _primaryBuffer.ToString().Substring(0, (primaryLength) - (0)), _secondaryBuffer.ToString().Substring(0, (secondaryLength) - (0)) };
            }
        }

    }
}
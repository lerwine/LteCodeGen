using System.Globalization;

namespace TestDataGeneration.Numerics;

public static partial class Fraction
{
    public class TokenMatcher
    {
        public NumberFormatInfo FormatInfo { get; }

        public string CurrencySymbol { get; }

        public string GroupSeparator { get; }

        public string DecimalSeparator { get; }

        public string PositiveSign { get; }

        public string NegativeSign { get; }

        public bool TryMatchExponent(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            throw new NotImplementedException();
        }

        public bool TryMatchNumber(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            throw new NotImplementedException();
        }

        private delegate bool TryMatch(ReadOnlySpan<char> s, int startIndex, out int endIndex);

        #region  NumberStyles.None

        private bool TryMatchNumber_0_0(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (TryMatchGroup(s, startIndex, out endIndex))
            {
                if (TryMatchDigits(s, startIndex + 1, out int endDigits) && endDigits + 1 == endIndex) return true;
            }
            else
            {
                if (!_tryMatchPositiveSign(s, startIndex, out int nextIndex)) _tryMatchNegativeSign(s, nextIndex, out nextIndex);
                if (TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_0_1(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (!_tryMatchNegativeSign(s, startIndex, out int nextIndex)) _tryMatchPositiveSign(s, nextIndex, out nextIndex);
            if (TryMatchDigits(s, nextIndex, out endIndex)) return true;
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_0_2(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (_tryMatchNegativeSign(s, startIndex, out int nextIndex))
                TryMatchWhiteSpace(s, startIndex, out startIndex);
            else
                _tryMatchPositiveSign(s, startIndex, out nextIndex);
            if (TryMatchDigits(s, nextIndex, out endIndex)) return true;
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_0_3(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (_tryMatchPositiveSign(s, startIndex, out int nextIndex))
            {
                if (TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            else
            {
                if (TryMatchDigits(s, startIndex, out endIndex))
                {
                    _tryMatchNegativeSign(s, endIndex, out endIndex);
                    return true;
                }
                if (_tryMatchNegativeSign(s, startIndex, out nextIndex) && TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_0_4(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (_tryMatchPositiveSign(s, startIndex, out int nextIndex))
            {
                if (TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            else
            {
                if (TryMatchDigits(s, startIndex, out endIndex))
                {
                    if (TryMatchWhiteSpace(s, endIndex, out int endOfWs))
                    {
                        if (_tryMatchNegativeSign(s, endOfWs, out endOfWs)) endIndex = endOfWs;
                    }
                    else
                        _tryMatchNegativeSign(s, endIndex, out endIndex);
                    return true;
                }
                if (_tryMatchNegativeSign(s, startIndex, out nextIndex))
                {
                    TryMatchWhiteSpace(s, nextIndex, out nextIndex);
                    if (TryMatchDigits(s, nextIndex, out endIndex)) return true;
                }
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_1_0(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (TryMatchGroup(s, startIndex, out endIndex))
            {
                if (TryMatchDigits(s, startIndex + 1, out int endDigits) && endDigits + 1 == endIndex) return true;
            }
            else
            {
                if (TryMatchDigits(s, startIndex, out endIndex))
                {
                    _tryMatchPositiveSign(s, endIndex, out endIndex);
                    return true;
                }
                if (_tryMatchPositiveSign(s, startIndex, out int nextIndex) && TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_1_1(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (TryMatchGroup(s, startIndex, out endIndex))
            {
                if (TryMatchDigits(s, startIndex + 1, out int endDigits) && endDigits + 1 == endIndex) return true;
            }
            else
            {
                if (TryMatchDigits(s, startIndex, out endIndex))
                {
                    _tryMatchPositiveSign(s, endIndex, out endIndex);
                    return true;
                }
                if (_tryMatchPositiveSign(s, startIndex, out int nextIndex) && TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_1_2(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (_tryMatchNegativeSign(s, startIndex, out endIndex))
            {
                if (TryMatchDigits(s, startIndex, out endIndex)) return true;
            }
            else
            {
                if (TryMatchDigits(s, startIndex, out endIndex))
                {
                    _tryMatchPositiveSign(s, endIndex, out endIndex);
                    return true;
                }
                if (_tryMatchPositiveSign(s, startIndex, out int nextIndex) && TryMatchDigits(s, nextIndex, out endIndex)) return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_1_3(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (TryMatchDigits(s, startIndex, out endIndex))
            {
                if (!_tryMatchNegativeSign(s, endIndex, out endIndex)) _tryMatchPositiveSign(s, endIndex, out endIndex);
                return true;
            }
            if ((_tryMatchNegativeSign(s, startIndex, out int nextIndex) || _tryMatchPositiveSign(s, startIndex, out nextIndex)) && TryMatchDigits(s, nextIndex, out endIndex)) return true;
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_1_4(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            int nextIndex;
            if (TryMatchDigits(s, startIndex, out endIndex))
            {
                if (TryMatchWhiteSpace(s, endIndex, out nextIndex))
                {
                    if (_tryMatchNegativeSign(s, nextIndex, out nextIndex)) endIndex = nextIndex;
                }
                else if (!_tryMatchNegativeSign(s, startIndex, out nextIndex))
                    _tryMatchPositiveSign(s, startIndex, out nextIndex);
                return true;
            }
            if ((_tryMatchNegativeSign(s, startIndex, out nextIndex) || _tryMatchPositiveSign(s, startIndex, out nextIndex)) && TryMatchDigits(s, nextIndex, out endIndex)) return true;
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchNumber_2_0(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+
            // Negative pattern: \(\d+\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+
            // Negative pattern: \(\d+\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+
            // Negative pattern: -\s*\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+
            // Negative pattern: \d+-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+
            // Negative pattern: \d+\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?
            // Negative pattern: \(\d+\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?
            // Negative pattern: -\s*\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?
            // Negative pattern: \(\d+\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?
            // Negative pattern: \d+-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?
            // Negative pattern: \d+\s*-
            throw new NotImplementedException();
        }

        #endregion

        #region NumberStyles.AllowExponent

        private bool TryMatchNumber_0_0_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\d+|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_E(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        #endregion

        #region  NumberStyles.AllowThousands

        private bool TryMatchNumber_0_0_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*
            // Negative pattern: -\d[\d,]*
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*
            // Negative pattern: -\s*\d[\d,]*
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*
            // Negative pattern: \d[\d,]*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*
            // Negative pattern: \d[\d,]*\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?
            // Negative pattern: -\s*\d[\d,]*
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?
            // Negative pattern: \d[\d,]*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?
            // Negative pattern: \d[\d,]*\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*
            // Negative pattern: -\s*\d[\d,]*
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*
            // Negative pattern: \d[\d,]*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*
            // Negative pattern: \d[\d,]*\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?
            // Negative pattern: -\s*\d[\d,]*
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?
            // Negative pattern: \(\d[\d,]*\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?
            // Negative pattern: \d[\d,]*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?
            // Negative pattern: \d[\d,]*\s*-
            throw new NotImplementedException();
        }

        #endregion

        #region NumberStyles.AllowExponent | NumberStyles.AllowThousands

        private bool TryMatchNumber_0_0_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\d[\d,]*|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_E_T(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        #endregion

        #region  NumberStyles.AllowDecimalPoint

        private bool TryMatchNumber_0_0_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?
            // Negative pattern: -\d+(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?
            // Negative pattern: -\s*\d+(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?
            // Negative pattern: \d+(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?
            // Negative pattern: \d+(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?
            // Negative pattern: -\s*\d+(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?
            // Negative pattern: \d+(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?
            // Negative pattern: \d+(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?
            // Negative pattern: -\s*\d+(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?
            // Negative pattern: \d+(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?
            // Negative pattern: \d+(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?
            // Negative pattern: -\s*\d+(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?
            // Negative pattern: \(\d+(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?
            // Negative pattern: \d+(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?
            // Negative pattern: \d+(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        #endregion

        #region NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint

        private bool TryMatchNumber_0_0_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\d+(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d+(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d+(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_E_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d+(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d+(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        #endregion

        #region  NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint

        private bool TryMatchNumber_0_0_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?
            // Negative pattern: -\d[\d,]*(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?
            // Negative pattern: \d[\d,]*(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?
            // Negative pattern: \d[\d,]*(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?
            // Negative pattern: \d[\d,]*(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?
            // Negative pattern: \d[\d,]*(\.\d+)?-
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-
            throw new NotImplementedException();
        }

        #endregion

        #region NumberStyles.AllowExponent | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint

        private bool TryMatchNumber_0_0_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_1_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_2_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_3_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_0_4_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_0_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_1_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_2_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_3_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_1_4_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_0_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_1_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_2_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_3_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_2_4_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \+?\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_0_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_1_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: -\s*\d[\d,]*(\.\d+)?|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_2_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \(\d[\d,]*(\.\d+)?\)|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_3_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        private bool TryMatchNumber_3_4_E_T_D(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            // Positive pattern: \d[\d,]*(\.\d+)?\s*\+?|\d+(\.\d+)[Ee]\+?\d+
            // Negative pattern: \d[\d,]*(\.\d+)?\s*-|\d+(\.\d+)[Ee]-\d+
            throw new NotImplementedException();
        }

        #endregion

        private readonly TryMatch _tryMatchNumber;
        private readonly TryMatch _tryMatchPositiveSign;
        private readonly TryMatch _tryMatchNegativeSign;

        private static bool TryMatchPosDefault(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (s[0] == Positive_Prefix_Char)
            {
                endIndex = startIndex + 1;
                return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchPosDefaultPos(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (s[0] == Positive_Prefix_Char)
            {
                if (!TryMatchSequence(s, startIndex, PositiveSign, out endIndex)) endIndex = startIndex + 1;
                return true;
            }
            endIndex = startIndex;
            return false;
        }

        private bool TryMatchPosDefaultOrPos(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            if (s[0] == Positive_Prefix_Char)
            {
                endIndex = startIndex + 1;
                return true;
            }
            return TryMatchSequence(s, startIndex, PositiveSign, out endIndex);
        }

        private static bool TryMatchNegDefault(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            switch (s[0])
            {
                case Negative_Prefix_Char:
                case AltNegative_Prefix_Char:
                    endIndex = startIndex + 1;
                    return true;
                default:
                    endIndex = startIndex;
                    return false;
            }
        }

        private bool TryMatchNegDefaultOrNeg(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            switch (s[0])
            {
                case Negative_Prefix_Char:
                case AltNegative_Prefix_Char:
                    endIndex = startIndex + 1;
                    return true;
                default:
                    return TryMatchSequence(s, startIndex, NegativeSign, out endIndex);
            }
        }

        private bool TryMatchNegDefaultNeg(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            switch (s[0])
            {
                case Negative_Prefix_Char:
                    if (!TryMatchSequence(s, startIndex, NegativeSign, out endIndex)) endIndex = startIndex + 1;
                    return true;
                case AltNegative_Prefix_Char:
                    endIndex = startIndex + 1;
                    return true;
                default:
                    endIndex = startIndex;
                    return false;
            }
        }

        private bool TryMatchNegDefaultNegAlt(ReadOnlySpan<char> s, int startIndex, out int endIndex)
        {
            switch (s[0])
            {
                case AltNegative_Prefix_Char:
                    if (!TryMatchSequence(s, startIndex, NegativeSign, out endIndex)) endIndex = startIndex + 1;
                    return true;
                case Negative_Prefix_Char:
                    endIndex = startIndex + 1;
                    return true;
                default:
                    endIndex = startIndex;
                    return false;
            }
        }

        public TokenMatcher(NumberFormatInfo formatInfo, NumberStyles styles)
        {
            FormatInfo = formatInfo ??= _defaultFormatInfo;
            CurrencySymbol = string.IsNullOrEmpty(formatInfo.CurrencySymbol) ? "$" : formatInfo.CurrencySymbol;
            if (string.IsNullOrEmpty(formatInfo.PositiveSign))
            {
                PositiveSign = Positive_Prefix_Char.ToString();
                _tryMatchPositiveSign = TryMatchPosDefault;
            }
            else if ((PositiveSign = formatInfo.PositiveSign).Length == 1)
                _tryMatchPositiveSign = (PositiveSign[0] == Positive_Prefix_Char) ? TryMatchPosDefault : TryMatchPosDefaultOrPos;
            else
                _tryMatchPositiveSign = (PositiveSign[0] == Positive_Prefix_Char) ? TryMatchPosDefaultPos : TryMatchPosDefaultOrPos;
            if (string.IsNullOrEmpty(formatInfo.NegativeSign))
            {
                NegativeSign = Negative_Prefix_Char.ToString();
                _tryMatchNegativeSign = TryMatchNegDefault;
            }
            else if ((NegativeSign = formatInfo.NegativeSign).Length == 1)
                _tryMatchNegativeSign = NegativeSign[0] switch
                {
                    Negative_Prefix_Char or AltNegative_Prefix_Char => TryMatchNegDefault,
                    _ => TryMatchNegDefaultOrNeg,
                };
            else
                _tryMatchNegativeSign = NegativeSign[0] switch
                {
                    Negative_Prefix_Char => TryMatchNegDefaultNeg,
                    AltNegative_Prefix_Char => TryMatchNegDefaultNegAlt,
                    _ => TryMatchNegDefaultOrNeg,
                };
            int negativePattern, positivePattern;
            if (styles.HasFlag(NumberStyles.AllowCurrencySymbol))
            {
                GroupSeparator = string.IsNullOrEmpty(formatInfo.CurrencyGroupSeparator) ? "," : formatInfo.CurrencyGroupSeparator;
                DecimalSeparator = string.IsNullOrEmpty(formatInfo.CurrencyDecimalSeparator) ? "." : formatInfo.CurrencyDecimalSeparator;
                negativePattern = formatInfo.CurrencyNegativePattern;
                positivePattern = (styles.HasFlag(NumberStyles.AllowLeadingSign) || !styles.HasFlag(NumberStyles.AllowTrailingSign)) ? (styles.HasFlag(NumberStyles.AllowLeadingWhite) ? 2 : 0) :
                    styles.HasFlag(NumberStyles.AllowTrailingWhite) ? 3 : 1;
            }
            else
            {
                GroupSeparator = string.IsNullOrEmpty(formatInfo.NumberGroupSeparator) ? "," : formatInfo.NumberGroupSeparator;
                DecimalSeparator = string.IsNullOrEmpty(formatInfo.NumberDecimalSeparator) ? "." : formatInfo.NumberDecimalSeparator;
                negativePattern = formatInfo.NumberNegativePattern;
                positivePattern = formatInfo.CurrencyPositivePattern;
            }
            if (styles.HasFlag(NumberStyles.AllowDecimalPoint))
            {
                if (styles.HasFlag(NumberStyles.AllowThousands))
                {
                    if (styles.HasFlag(NumberStyles.AllowExponent))
                        _tryMatchNumber = negativePattern switch
                        {
                            1 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_1_E_T_D,
                                2 => TryMatchNumber_2_1_E_T_D,
                                3 => TryMatchNumber_3_1_E_T_D,
                                _ => TryMatchNumber_0_1_E_T_D
                            },
                            2 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_2_E_T_D,
                                2 => TryMatchNumber_2_2_E_T_D,
                                3 => TryMatchNumber_3_2_E_T_D,
                                _ => TryMatchNumber_0_2_E_T_D
                            },
                            3 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_3_E_T_D,
                                2 => TryMatchNumber_2_3_E_T_D,
                                3 => TryMatchNumber_3_3_E_T_D,
                                _ => TryMatchNumber_0_3_E_T_D
                            },
                            4 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_4_E_T_D,
                                2 => TryMatchNumber_2_4_E_T_D,
                                3 => TryMatchNumber_3_4_E_T_D,
                                _ => TryMatchNumber_0_4_E_T_D
                            },
                            _ => positivePattern switch
                            {
                                1 => TryMatchNumber_1_0_E_T_D,
                                2 => TryMatchNumber_2_0_E_T_D,
                                3 => TryMatchNumber_3_0_E_T_D,
                                _ => TryMatchNumber_0_0_E_T_D
                            }
                        };
                    else
                        _tryMatchNumber = negativePattern switch
                        {
                            1 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_1_T_D,
                                2 => TryMatchNumber_2_1_T_D,
                                3 => TryMatchNumber_3_1_T_D,
                                _ => TryMatchNumber_0_1_T_D
                            },
                            2 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_2_T_D,
                                2 => TryMatchNumber_2_2_T_D,
                                3 => TryMatchNumber_3_2_T_D,
                                _ => TryMatchNumber_0_2_T_D
                            },
                            3 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_3_T_D,
                                2 => TryMatchNumber_2_3_T_D,
                                3 => TryMatchNumber_3_3_T_D,
                                _ => TryMatchNumber_0_3_T_D
                            },
                            4 => positivePattern switch
                            {
                                1 => TryMatchNumber_1_4_T_D,
                                2 => TryMatchNumber_2_4_T_D,
                                3 => TryMatchNumber_3_4_T_D,
                                _ => TryMatchNumber_0_4_T_D
                            },
                            _ => positivePattern switch
                            {
                                1 => TryMatchNumber_1_0_T_D,
                                2 => TryMatchNumber_2_0_T_D,
                                3 => TryMatchNumber_3_0_T_D,
                                _ => TryMatchNumber_0_0_T_D
                            }
                        };
                }
                else if (styles.HasFlag(NumberStyles.AllowExponent))
                    _tryMatchNumber = negativePattern switch
                    {
                        1 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_1_E_D,
                            2 => TryMatchNumber_2_1_E_D,
                            3 => TryMatchNumber_3_1_E_D,
                            _ => TryMatchNumber_0_1_E_D
                        },
                        2 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_2_E_D,
                            2 => TryMatchNumber_2_2_E_D,
                            3 => TryMatchNumber_3_2_E_D,
                            _ => TryMatchNumber_0_2_E_D
                        },
                        3 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_3_E_D,
                            2 => TryMatchNumber_2_3_E_D,
                            3 => TryMatchNumber_3_3_E_D,
                            _ => TryMatchNumber_0_3_E_D
                        },
                        4 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_4_E_D,
                            2 => TryMatchNumber_2_4_E_D,
                            3 => TryMatchNumber_3_4_E_D,
                            _ => TryMatchNumber_0_4_E_D
                        },
                        _ => positivePattern switch
                        {
                            1 => TryMatchNumber_1_0_E_D,
                            2 => TryMatchNumber_2_0_E_D,
                            3 => TryMatchNumber_3_0_E_D,
                            _ => TryMatchNumber_0_0_E_D
                        }
                    };
                else
                    _tryMatchNumber = negativePattern switch
                    {
                        1 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_1_D,
                            2 => TryMatchNumber_2_1_D,
                            3 => TryMatchNumber_3_1_D,
                            _ => TryMatchNumber_0_1_D
                        },
                        2 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_2_D,
                            2 => TryMatchNumber_2_2_D,
                            3 => TryMatchNumber_3_2_D,
                            _ => TryMatchNumber_0_2_D
                        },
                        3 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_3_D,
                            2 => TryMatchNumber_2_3_D,
                            3 => TryMatchNumber_3_3_D,
                            _ => TryMatchNumber_0_3_D
                        },
                        4 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_4_D,
                            2 => TryMatchNumber_2_4_D,
                            3 => TryMatchNumber_3_4_D,
                            _ => TryMatchNumber_0_4_D
                        },
                        _ => positivePattern switch
                        {
                            1 => TryMatchNumber_1_0_D,
                            2 => TryMatchNumber_2_0_D,
                            3 => TryMatchNumber_3_0_D,
                            _ => TryMatchNumber_0_0_D
                        }
                    };
            }
            else if (styles.HasFlag(NumberStyles.AllowThousands))
            {
                if (styles.HasFlag(NumberStyles.AllowExponent))
                    _tryMatchNumber = negativePattern switch
                    {
                        1 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_1_E_T,
                            2 => TryMatchNumber_2_1_E_T,
                            3 => TryMatchNumber_3_1_E_T,
                            _ => TryMatchNumber_0_1_E_T
                        },
                        2 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_2_E_T,
                            2 => TryMatchNumber_2_2_E_T,
                            3 => TryMatchNumber_3_2_E_T,
                            _ => TryMatchNumber_0_2_E_T
                        },
                        3 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_3_E_T,
                            2 => TryMatchNumber_2_3_E_T,
                            3 => TryMatchNumber_3_3_E_T,
                            _ => TryMatchNumber_0_3_E_T
                        },
                        4 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_4_E_T,
                            2 => TryMatchNumber_2_4_E_T,
                            3 => TryMatchNumber_3_4_E_T,
                            _ => TryMatchNumber_0_4_E_T
                        },
                        _ => positivePattern switch
                        {
                            1 => TryMatchNumber_1_0_E_T,
                            2 => TryMatchNumber_2_0_E_T,
                            3 => TryMatchNumber_3_0_E_T,
                            _ => TryMatchNumber_0_0_E_T
                        }
                    };
                else
                    _tryMatchNumber = negativePattern switch
                    {
                        1 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_1_T,
                            2 => TryMatchNumber_2_1_T,
                            3 => TryMatchNumber_3_1_T,
                            _ => TryMatchNumber_0_1_T
                        },
                        2 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_2_T,
                            2 => TryMatchNumber_2_2_T,
                            3 => TryMatchNumber_3_2_T,
                            _ => TryMatchNumber_0_2_T
                        },
                        3 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_3_T,
                            2 => TryMatchNumber_2_3_T,
                            3 => TryMatchNumber_3_3_T,
                            _ => TryMatchNumber_0_3_T
                        },
                        4 => positivePattern switch
                        {
                            1 => TryMatchNumber_1_4_T,
                            2 => TryMatchNumber_2_4_T,
                            3 => TryMatchNumber_3_4_T,
                            _ => TryMatchNumber_0_4_T
                        },
                        _ => positivePattern switch
                        {
                            1 => TryMatchNumber_1_0_T,
                            2 => TryMatchNumber_2_0_T,
                            3 => TryMatchNumber_3_0_T,
                            _ => TryMatchNumber_0_0_T
                        }
                    };
            }
            else if (styles.HasFlag(NumberStyles.AllowExponent))
                _tryMatchNumber = negativePattern switch
                {
                    1 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_1_E,
                        2 => TryMatchNumber_2_1_E,
                        3 => TryMatchNumber_3_1_E,
                        _ => TryMatchNumber_0_1_E
                    },
                    2 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_2_E,
                        2 => TryMatchNumber_2_2_E,
                        3 => TryMatchNumber_3_2_E,
                        _ => TryMatchNumber_0_2_E
                    },
                    3 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_3_E,
                        2 => TryMatchNumber_2_3_E,
                        3 => TryMatchNumber_3_3_E,
                        _ => TryMatchNumber_0_3_E
                    },
                    4 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_4_E,
                        2 => TryMatchNumber_2_4_E,
                        3 => TryMatchNumber_3_4_E,
                        _ => TryMatchNumber_0_4_E
                    },
                    _ => positivePattern switch
                    {
                        1 => TryMatchNumber_1_0_E,
                        2 => TryMatchNumber_2_0_E,
                        3 => TryMatchNumber_3_0_E,
                        _ => TryMatchNumber_0_0_E
                    }
                };
            else
                _tryMatchNumber = negativePattern switch
                {
                    1 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_1,
                        2 => TryMatchNumber_2_1,
                        3 => TryMatchNumber_3_1,
                        _ => TryMatchNumber_0_1
                    },
                    2 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_2,
                        2 => TryMatchNumber_2_2,
                        3 => TryMatchNumber_3_2,
                        _ => TryMatchNumber_0_2
                    },
                    3 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_3,
                        2 => TryMatchNumber_2_3,
                        3 => TryMatchNumber_3_3,
                        _ => TryMatchNumber_0_3
                    },
                    4 => positivePattern switch
                    {
                        1 => TryMatchNumber_1_4,
                        2 => TryMatchNumber_2_4,
                        3 => TryMatchNumber_3_4,
                        _ => TryMatchNumber_0_4
                    },
                    _ => positivePattern switch
                    {
                        1 => TryMatchNumber_1_0,
                        2 => TryMatchNumber_2_0,
                        3 => TryMatchNumber_3_0,
                        _ => TryMatchNumber_0_0
                    }
                };
        }

        public TokenMatcher(NumberStyles styles, IFormatProvider? provider) : this((provider?.GetFormat(typeof(NumberFormatInfo)) as NumberFormatInfo)!, styles) { }
    }
}

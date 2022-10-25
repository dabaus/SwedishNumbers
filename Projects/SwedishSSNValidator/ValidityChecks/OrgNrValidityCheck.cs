using System.Text.RegularExpressions;
using SwedishSSNValidator.ValidityChecks.Interfaces;

namespace SwedishSSNValidator.ValidityChecks
{
    public class OrgNrValidityCheck : IOrgNrValidityCheck
    {
        private static readonly Regex LongFormRegex = new Regex("^(16)[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormRegex = new Regex("^[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);

        private ILuhnsChecksumValidityCheck _luhnsCheck;

        public OrgNrValidityCheck(ILuhnsChecksumValidityCheck luhnsCheck)
        {
            _luhnsCheck = luhnsCheck;
        }

        public bool IsValid(string input)
        {

            if (LongFormRegex.IsMatch(input))
            {
                var normalized = input.Substring(2).Replace("-", "");
                return IsThirdDigitValid(normalized) && _luhnsCheck.IsValid(normalized);
            }
            if (ShortFormRegex.IsMatch(input))
            {
                var normalized = input.Replace("-", "");
                return IsThirdDigitValid(normalized) && _luhnsCheck.IsValid(normalized);
            }
            return false;
        }

        private static bool IsThirdDigitValid(string input)
        {
            if(int.TryParse(input.Substring(2, 1), out var result))
            {
                return result >= 2;
            }
            return false;
        }
    }
}

using System;
using System.Text.RegularExpressions;
using SwedishSSNValidator.ValidityChecks.Interfaces;

namespace SwedishSSNValidator.ValidityChecks
{

    public class PersonNrValidityCheck : IPersonNrValidityCheck
    {
        private static readonly Regex LongFormatRegex = new Regex("^(18|19|20)[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormPlusSeparatorRegex = new Regex("^[0-9]{6}(\\+)[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormatRegex = new Regex("^[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);

        private ILuhnsChecksumValidityCheck _luhnsCheck;
        private IDateValidityCheck _dateCheck;


        public PersonNrValidityCheck(
            ILuhnsChecksumValidityCheck luhnsCheck,
            IDateValidityCheck dateCheck)
        {
            _luhnsCheck = luhnsCheck;
            _dateCheck = dateCheck;

        }

        public bool IsValid(string input)
        {
            if (LongFormatRegex.IsMatch(input))
            {
                var normalized = input.Substring(2).Replace("-", "");
                return _dateCheck.IsValid(input.Substring(0, 8)) && _luhnsCheck.IsValid(normalized);
            }
            if (ShortFormatRegex.IsMatch(input))
            {
                var normalized = input.Replace("-", "");
                return _dateCheck.IsValid(input.Substring(0, 6)) && _luhnsCheck.IsValid(normalized);
            }
            if (ShortFormPlusSeparatorRegex.IsMatch(input))
            {
                var normalized = input.Replace("+", "");
                return _dateCheck.IsValid(input.Substring(0, 6)) && _luhnsCheck.IsValid(normalized);
            }
            return false;
        }
    }
}

using System;
using System.Text.RegularExpressions;


namespace SwedishSSNValidator {

    public interface IPersonnummerValidityCheck : IValidityCheck
    {
    }

    public class PersonNrValidityCheck : IPersonnummerValidityCheck
    {
        private static readonly Regex StartsWithYearRegex = new Regex("^(18|19|20)[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormPlusSeparatorRegex = new Regex("^[0-9]{6}(\\+)[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormRegex = new Regex("^[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);

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
            bool startsWithYear = StartsWithYearRegex.IsMatch(input);
            bool isShortForm = ShortFormRegex.IsMatch(input);
            bool isShortFormWithPlus = ShortFormPlusSeparatorRegex.IsMatch(input);

            if (startsWithYear)
            {
                var normalized = input.Substring(2).Replace("-", "");
                return _dateCheck.IsValid(input.Substring(0, 8)) && _luhnsCheck.IsValid(normalized);
            }
            if (isShortForm)
            {
                var normalized = input.Replace("-", "");
                return _dateCheck.IsValid(input.Substring(0, 6)) && _luhnsCheck.IsValid(normalized);
            }
            if (isShortFormWithPlus)
            {
                var normalized = input.Replace("+", "");
                return _dateCheck.IsValid(input.Substring(0, 6)) && _luhnsCheck.IsValid(normalized);
            }
            return false;
        }
    }
}

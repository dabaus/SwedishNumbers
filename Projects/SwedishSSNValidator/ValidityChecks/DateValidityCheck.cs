using System.Globalization;
using SwedishSSNValidator.ValidityChecks.Interfaces;


namespace SwedishSSNValidator.ValidityChecks
{

    public class DateValidityCheck : IDateValidityCheck
    {
        public bool IsValid(string input)
        {
            if (input.Length == 8)
            {
                return LongDateValid(input);
            }
            if (input.Length == 6)
            {
                return ShortDateValid(input);
            }
            return false;
        }

        private static bool LongDateValid(string dateStr)
        {
            return DateTime.TryParseExact(dateStr,
                       "yyyyMMdd",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out var _);
        }

        private static bool ShortDateValid(string dateStr)
        {
            return DateTime.TryParseExact(dateStr,
                       "yyMMdd",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out var _);
        }
    }
}

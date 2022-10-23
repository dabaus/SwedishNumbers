using System.Text.RegularExpressions;

namespace SwedishSSNValidator.ValidityChecks
{
    public interface ISammordningsNrDateCheck : IDateValidityCheck
    {

    }

    public class SammordningsNrDateCheck : ISammordningsNrDateCheck
    {
        private IDateValidityCheck _dateCheck;

        public SammordningsNrDateCheck(IDateValidityCheck dateCheck)
        {
            _dateCheck = dateCheck;
        }

        public bool IsValid(string input)
        {
            if (input.Length < 6)
            {
                return false;
            }
            try
            {
                return _dateCheck.IsValid(Subtract60(input));
            }
            catch (FormatException _)
            {
                return false;
            }
        }

        private static string Subtract60(string input)
        {
            var lastDigits = input.Substring(input.Length - 2);
            return $"{input.Remove(input.Length - 2)}{int.Parse(lastDigits) - 60}";
        }
    }
}

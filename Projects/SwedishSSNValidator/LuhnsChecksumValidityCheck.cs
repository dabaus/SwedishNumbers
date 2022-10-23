using System.Text.RegularExpressions;

namespace SwedishSSNValidator
{
    public interface ILuhnsChecksumValidityCheck : IValidityCheck
    {
    }

    public class LuhnsChecksumValidityCheck : ILuhnsChecksumValidityCheck
    {
        private static readonly Regex IsNumeric = new Regex("^[0-9]*$", RegexOptions.Compiled);

        public bool IsValid(string input)
        {
            if(!IsNumeric.IsMatch(input))
            {
                return false;
            } 

            var controlDigit = int.Parse(input.Substring(input.Length - 1));
            var chars = input.Remove(input.Length - 1).ToCharArray();
            var products = new string[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                var number = ToInt(chars[i]);
                if (i % 2 == 0)
                {
                    products[i] = (number * 2).ToString();
                }
                else
                {
                    products[i] = number.ToString();
                }
            }
            var sum = products.SelectMany(x => x.ToCharArray())
                .Sum(x => ToInt(x));
            var computedDigit = (10 - (sum % 10)) % 10;

            return controlDigit == computedDigit;
        }

        private static int ToInt(char c)
        {
            return (int)(c - '0');
        }
    }
}

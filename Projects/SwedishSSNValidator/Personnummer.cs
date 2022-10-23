using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SwedishSSNValidator { 


    public static class Personnummer
    {
        private static readonly Regex StartsWithYearRegex = new Regex("^(18|19|20)[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormPlusSeparatorRegex = new Regex("^[0-9]{6}(\\+)[0-9]{4}$", RegexOptions.Compiled);
        private static readonly Regex ShortFormRegex = new Regex("^[0-9]{6}[\\-]?[0-9]{4}$", RegexOptions.Compiled);

  
        public static bool IsValid(string input)
        {
            bool startsWithYear = StartsWithYearRegex.IsMatch(input);
            bool isShortForm = ShortFormRegex.IsMatch(input);
            bool isShortFormWithPlus = ShortFormPlusSeparatorRegex.IsMatch(input);

            if (startsWithYear)
            {
                var normalized = input.Substring(2).Replace("-", "");
                return IsChecksumValid(normalized);
            }
            if(isShortForm)
            {
                var normalized = input.Replace("-", "");
                return IsChecksumValid(normalized);
            }
            if(isShortFormWithPlus)
            {
                var normalized = input.Replace("+", "");
                return IsChecksumValid(normalized);
            }
            return false;
        }

    
        private static bool IsChecksumValid(string input)
        {
            var controlDigit = int.Parse(input.Substring(input.Length - 1));
            var chars = input.Remove(input.Length-1).ToCharArray();
            var products = new string[chars.Length];
            for (int i =0; i<chars.Length; i++)
            {
                var number = ToInt(chars[i]);
                if (i % 2 == 0)
                {
                    products[i] = (number * 2).ToString();
                } else
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

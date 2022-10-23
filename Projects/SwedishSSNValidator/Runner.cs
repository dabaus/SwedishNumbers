using SwedishSSNValidator.ValidityChecks;

namespace SwedishSSNValidator
{
    public class Runner
    {

        private readonly IPersonnummerValidityCheck _pNrVadilityCheck;
        private readonly ISammordningsNrValidityCheck _samNrVadilityCheck;
        private readonly IOrgNrValidityCheck _orgNrValidityCheck;

        public Runner(IPersonnummerValidityCheck pNrVadilityCheck,
                      ISammordningsNrValidityCheck samNrVadilityCheck,
                      IOrgNrValidityCheck orgNrValidityCheck)
        {

            _pNrVadilityCheck = pNrVadilityCheck;
            _samNrVadilityCheck = samNrVadilityCheck;
            _orgNrValidityCheck = orgNrValidityCheck;
        }

        public void Run()
        {
            Console.WriteLine("Input: ");
            var line = Console.ReadLine();
            while(line != null)
            {
                var trimmed = line.Trim();
                if (!_pNrVadilityCheck.IsValid(trimmed))
                {
                    Console.WriteLine($"{trimmed} is not a vaild swedish personnummer");
                }
                if (!_samNrVadilityCheck.IsValid(trimmed))
                {
                    Console.WriteLine($"{trimmed} is not a vaild swedish samordningsnummer");
                }
                if (!_orgNrValidityCheck.IsValid(trimmed))
                {
                    Console.WriteLine($"{trimmed} is not a vaild swedish organisationsnummer");
                }
                line = Console.ReadLine();
            }
     
        }
    }
}

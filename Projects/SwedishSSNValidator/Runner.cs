using SwedishSSNValidator.ValidityChecks;
using SwedishSSNValidator.ValidityChecks.Interfaces;

namespace SwedishSSNValidator
{
    public class Runner
    {

        private readonly IPersonNrValidityCheck _pNrVadilityCheck;
        private readonly ISammordningsNrValidityCheck _samNrVadilityCheck;
        private readonly IOrgNrValidityCheck _orgNrValidityCheck;

        public Runner(IPersonNrValidityCheck pNrVadilityCheck,
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishSSNValidator.ValidityChecks
{
    public interface ISammordningsNrValidityCheck : IValidityCheck
    {

    }

    public class SammordningsNrValidityCheck : ISammordningsNrValidityCheck
    {

        private IPersonnummerValidityCheck _pnrValidityCheck;

        public SammordningsNrValidityCheck(ILuhnsChecksumValidityCheck luhnsCheck, 
                                           ISammordningsNrDateValidityCheck dateCheck)
        {
            _pnrValidityCheck = new PersonNrValidityCheck(luhnsCheck, dateCheck);
        }

        public bool IsValid(string input)
        {
            return _pnrValidityCheck.IsValid(input);
        }
    }
}

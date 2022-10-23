using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishSSNValidator.ValidityChecks
{

    public class SammordningsNrValidityCheck : IValidityCheck
    {

        private IPersonnummerValidityCheck _pnrValidityCheck;

        public SammordningsNrValidityCheck(ILuhnsChecksumValidityCheck luhnsCheck, 
                                           ISammordningsNrDateCheck dateCheck)
        {
            _pnrValidityCheck = new PersonNrValidityCheck(luhnsCheck, dateCheck);
        }

        public bool IsValid(string input)
        {
            return _pnrValidityCheck.IsValid(input);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwedishSSNValidator.ValidityChecks.Interfaces;

namespace SwedishSSNValidator.ValidityChecks
{

    public class SammordningsNrValidityCheck : ISammordningsNrValidityCheck
    {

        private IPersonNrValidityCheck _pnrValidityCheck;

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

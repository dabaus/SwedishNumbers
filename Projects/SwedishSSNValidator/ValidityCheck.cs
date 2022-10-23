using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishSSNValidator
{
    public interface IValidityCheck
    {
        public bool IsValid(string input);
    }
}

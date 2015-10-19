using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericSequenceCalculator.Web.Contracts
{

    public interface ISequenceGenerator
    {
        IEnumerable<string> GetSequence(int input);
        string Name { get; }
    }

}

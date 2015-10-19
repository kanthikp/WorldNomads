using NumericSequenceCalculator.Web.App_Start;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericSequenceCalculator.Web.Contracts
{
   public  interface ISequenceGeneratorFactory
    {
       List<ISequenceGenerator> GetSequenceGenerators();
    }

}

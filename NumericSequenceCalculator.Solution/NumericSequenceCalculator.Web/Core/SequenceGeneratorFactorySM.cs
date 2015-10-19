using NumericSequenceCalculator.Web.Contracts;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Web.Core
{
    
    public class SequenceGeneratorFactorySM : ISequenceGeneratorFactory
    {
        private IContainer _smContainer;
        public SequenceGeneratorFactorySM(IContainer smContainer)
        {
            _smContainer = smContainer;
        }
        public List<ISequenceGenerator> GetSequenceGenerators()
        {
            return _smContainer.GetAllInstances<ISequenceGenerator>().ToList();
        }
    }
}
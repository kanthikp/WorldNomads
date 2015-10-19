using System;
using System.Collections.Generic;
using Rhino.Mocks;
using System.Web.Mvc;
using StructureMap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericSequenceCalculator.Web.Core;
using NumericSequenceCalculator.Web.Controllers;
using NumericSequenceCalculator.Web.Contracts;
using NumericSequenceCalculator.Web.Models;

namespace NumericSequenceCalculator.Web.Tests.Classes
{
    [TestClass]
    public class SequenceCalculationControllerTests
    {
        [TestMethod]
        public void SequenceCalculationController_SequenceGeneratorFactory_Can_GetAllInstances()
        {

            //Arrange
            IContainer mockContainer = MockRepository.GenerateMock<IContainer>();
            SequenceGeneratorFactorySM smFactory = new SequenceGeneratorFactorySM(mockContainer);
            ISequenceGenerator mockGenerator1 = MockRepository.GenerateMock<ISequenceGenerator>();

            List<ISequenceGenerator> seqGenList = new List<ISequenceGenerator>();
            seqGenList.Add(mockGenerator1);

            mockContainer.Expect(c => c.GetAllInstances<ISequenceGenerator>()).Return(seqGenList);

            //Act
            List<ISequenceGenerator> generators = smFactory.GetSequenceGenerators();

            //Assert
            mockContainer.VerifyAllExpectations();

        }

        [TestMethod]
        public void SequenceCalculationController_GenerateSequences_Can_CreateSequenceGenerators_And_InvokeGetSequence()
        {
            //Arrange
            ISequenceGeneratorFactory mockFactory = MockRepository.GenerateMock<ISequenceGeneratorFactory>();
            ISequenceGenerator mockGenerator = MockRepository.GenerateMock<ISequenceGenerator>();
            SequenceCalculationController controller = new SequenceCalculationController(mockFactory);
            List<ISequenceGenerator> generators = new List<ISequenceGenerator>();
            generators.Add(mockGenerator);
            
            
            GetSequenceInputViewModel inputVM = new GetSequenceInputViewModel();
            inputVM.Input = 10;

            mockFactory.Expect(f => f.GetSequenceGenerators())
                .Return(generators);

            mockGenerator.Expect(g => g.Name).Return("Test Sequence");
            string[] testSequence = { "1", "2", "3"};
            mockGenerator.Expect(g => g.GetSequence(inputVM.Input)).Return(testSequence);
            
            //Act
            ViewResult result = controller.GenerateSequences(inputVM) as ViewResult;

            //Assert
            mockFactory.VerifyAllExpectations();
            mockGenerator.VerifyAllExpectations();

            Assert.AreEqual(inputVM, result.ViewBag.GetSequenceInputViewModel);
            Assert.AreEqual(1, ((NumericSequenceViewModel)(result.ViewData.Model)).Sequences.Count);
            Assert.IsTrue(((Dictionary<string, IEnumerable<string>>)(((NumericSequenceViewModel)(result.ViewData.Model)).Sequences)).ContainsKey("Test Sequence"));
            Assert.AreEqual(testSequence, ((Dictionary<string, IEnumerable<string>>)(((NumericSequenceViewModel)(result.ViewData.Model)).Sequences))["Test Sequence"]);

        }


        [TestMethod]
        public void SequenceCalculationController_Index()
        {
            // Arrange
            ISequenceGeneratorFactory mockFactory = MockRepository.GenerateMock<ISequenceGeneratorFactory>();
            SequenceCalculationController controller = new SequenceCalculationController(mockFactory);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
              
    }
}

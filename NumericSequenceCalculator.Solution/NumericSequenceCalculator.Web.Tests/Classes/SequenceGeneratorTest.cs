using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericSequenceCalculator.Web.Core;
using System.Collections.Generic;

namespace NumericSequenceCalculator.Web.Tests.Classes
{
    [TestClass]
    public class SequenceGeneratorTest
    {


        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Invalid Argument: Input should be a whole number.")]
        public void SequenceGenerator_ValidateInput_ThrowException_WithInvalidInput()
        {
            // Arrange
            AllNumberSequenceGenerator seqGenerator = new AllNumberSequenceGenerator();

            //Act
            seqGenerator.GetSequence(0);
                        
        }

        [TestMethod]
        public void SequenceGenerator_GetAllNumberSequence_WithValidInput()
        {
            // Arrange
            AllNumberSequenceGenerator seqGenerator = new AllNumberSequenceGenerator();

            // Act
            var numSeq = seqGenerator.GetSequence(10);
            string[] expected = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            // Assert
            Assert.IsTrue(numSeq.SequenceEqual(expected));
        }



        [TestMethod]
        public void SequenceGenerator_GetOddNumberSequence_WithValidInput()
        {
            // Arrange
            OddNumberSequenceGenerator seqGenerator = new OddNumberSequenceGenerator();

            // Act
            var numSeq = seqGenerator.GetSequence(10);
            string[] expected = { "1", "3", "5", "7", "9" };

            // Assert
            Assert.IsTrue(numSeq.SequenceEqual(expected));
        }

        [TestMethod]
        public void SequenceGenerator_GetEvenNumberSequence_WithValidInput()
        {
            // Arrange
            EvenNumberSequenceGenerator seqGenerator = new EvenNumberSequenceGenerator();

            // Act
            var numSeq = seqGenerator.GetSequence(10);
            string[] expected = { "2", "4", "6", "8", "10" };

            // Assert
            Assert.IsTrue(numSeq.SequenceEqual(expected));
        }

        [TestMethod]
        public void SequenceGenerator_GetSpecialNumberSequence_WithValidInput()
        {
            // Arrange
            SpecialNumberSequenceGenerator seqGenerator = new SpecialNumberSequenceGenerator();

            // Act
            var numSeq = seqGenerator.GetSequence(15);
            string[] expected = { "1", "2", "C", "4", "E", "C", "7", "8", "C", "E", "11", "C", "13", "14", "Z" };

            // Assert
            Assert.IsTrue(numSeq.SequenceEqual(expected));

        }

        [TestMethod]
        public void SequenceGenerator_GetFibonacciNumberSequence_WithValidInput()
        {
            // Arrange
            FibonacciNumberSequenceGenerator seqGenerator = new FibonacciNumberSequenceGenerator();

            // Act
            var numSeq = seqGenerator.GetSequence(10);
            string[] expected = { "1", "1", "2", "3", "5", "8" };

            // Assert
            Assert.IsTrue(numSeq.SequenceEqual(expected));
        }

    }
}

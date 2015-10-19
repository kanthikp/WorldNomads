using NumericSequenceCalculator.Web.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Web.Core
{
    public abstract class SequenceGeneratorBase: ISequenceGenerator
    {
        public int Input { get; set; }

        public void Validate(int input)
        {
            if (input <= 0) throw new ArgumentException("Invalid Argument: Input should be a whole number.");
            Input = input;
        }

        protected abstract IEnumerable<string> GetActualSequence();

        public abstract string Name { get; }

        public IEnumerable<string> GetSequence(int input)
        {
            Validate(input);

            return GetActualSequence();
        }
    }

    public class AllNumberSequenceGenerator : SequenceGeneratorBase
    {
        protected override IEnumerable<string> GetActualSequence()
        {
            return Enumerable.Range(1, Input).AsStrings();
        }

        public override string Name
        {
            get { return "All Numbers"; }
        }
    }

    
    public class OddNumberSequenceGenerator : SequenceGeneratorBase
    {
        protected override IEnumerable<string> GetActualSequence()
        {
            return Enumerable.Range(1, Input).Where(num => num % 2 != 0).AsStrings();
        }


        public override string Name
        {
            get { return "Odd Numbers"; }
        }
    }

    public class EvenNumberSequenceGenerator : SequenceGeneratorBase
    {
        protected override IEnumerable<string> GetActualSequence()
        {
            return Enumerable.Range(1, Input).Where(num => num % 2 == 0).AsStrings();
        }


        public override string Name
        {
            get { return "Even Numbers"; }
        }
    }

    public class FibonacciNumberSequenceGenerator : SequenceGeneratorBase
    {
        protected override IEnumerable<string> GetActualSequence()
        {

            int f1 = 1, f2 = 1, f3 = 0;

            yield return f1.ToString();
            yield return f2.ToString();

            f3 = f1 + f2;
            while (f3 <= Input)
            {
                yield return f3.ToString();
                f1 = f2;
                f2 = f3;
                f3 = f1 + f2;
            }
        }


        public override string Name
        {
            get { return "Fibonacci Numbers"; }
        }
    }

    public class SpecialNumberSequenceGenerator : SequenceGeneratorBase
    {
        protected override IEnumerable<string> GetActualSequence()
        {
            var sequence = Enumerable.Range(1, Input);

            foreach (int i in sequence)
            {
                if (i % 15 == 0)
                    yield return "Z";
                else if (i % 5 == 0)
                    yield return "E";
                else if (i % 3 == 0)
                    yield return "C";
                else
                    yield return i.ToString();
            }
        }


        public override string Name
        {
            get { return "Special Numbers"; }
        }
    }
}
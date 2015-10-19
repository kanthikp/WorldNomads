using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Web.Models
{
    public class NumericSequenceViewModel
    {
        public int Limit;
        public NumericSequenceViewModel()
        {
            Sequences = new Dictionary<string, IEnumerable<string>>();
        }
        public Dictionary<string, IEnumerable<string>> Sequences { get; set; }
    }

   
}
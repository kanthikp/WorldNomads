using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NumericSequenceCalculator.Web.Models
{
    public class GetSequenceInputViewModel
    {
        [Range(1, 100000, ErrorMessage = "Input should be between 1 and 100000 and a whole number!!")]
        
        public int Input { get; set; }

    }

    //public class WholeNumberAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid
    //      (object value, ValidationContext validationContext)
    //    {
    //        if(value<0 &&
    //        return ValidationResult.Success;
    //    }
    //}
}
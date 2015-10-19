using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Web.Core
{
    public static class ExtensionMethodIEnumerable
    {
        public static IEnumerable<string> AsStrings(this IEnumerable<int> source)
        {
            return source.Select(i => i.ToString());
        }
    }
}
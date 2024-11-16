using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if(obj == null) return false;
            if(obj is string text && string.IsNullOrWhiteSpace(text)) return false;

            return true;
        }
    }
}

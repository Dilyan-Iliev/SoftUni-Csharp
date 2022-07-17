namespace ValidationAttributes.Attributes
{
    using System;
    using System.Linq;

    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}

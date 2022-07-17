namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
           // int intValue = (int)obj //cast it or below

            if (obj is int intValue)
            {
                if (intValue < minValue || intValue > maxValue)
                {
                    return false;
                }

                return true;
            }

            throw new ArgumentException("Invalid type!");
        }
    }
}

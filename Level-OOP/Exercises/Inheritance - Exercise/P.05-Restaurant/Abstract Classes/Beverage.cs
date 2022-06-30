using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public abstract class Beverage : Product, IBeverage
    {
        protected Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            Milliliters = milliliters;
        }

        public double Milliliters { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public abstract class MainDish : Food
    {
        protected MainDish(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
        }
    }
}

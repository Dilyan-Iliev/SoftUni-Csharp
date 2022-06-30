using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public interface IBeverage : IProduct
    {
        double Milliliters { get; }
    }
}

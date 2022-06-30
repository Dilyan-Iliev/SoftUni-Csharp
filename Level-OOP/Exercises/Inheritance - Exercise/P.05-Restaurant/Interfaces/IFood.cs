using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public interface IFood : IProduct
    {
        double Grams { get; }
    }
}

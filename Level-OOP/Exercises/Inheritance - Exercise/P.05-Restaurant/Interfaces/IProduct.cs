using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
    }
}

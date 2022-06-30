using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public interface IAnimal
    {
        string Name { get; }
        int Age { get; }
        string Gender { get; }
        string ProduceSound();
    }
}

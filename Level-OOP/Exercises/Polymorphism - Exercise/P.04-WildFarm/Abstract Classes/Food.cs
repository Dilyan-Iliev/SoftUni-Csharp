using System;
using System.Collections.Generic;
using System.Text;
using Wild_farm.Interfaces;

namespace Wild_farm.Abstract_Classes
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; set; }
    }
}

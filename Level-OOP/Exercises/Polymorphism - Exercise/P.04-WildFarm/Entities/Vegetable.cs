using System;
using System.Collections.Generic;
using System.Text;
using Wild_farm.Abstract_Classes;

namespace Wild_farm.Entities
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity) 
            : base(quantity)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Wild_farm.Abstract_Classes;

namespace Wild_farm.Entities
{
    public class Seeds : Food
    {
        public Seeds(int quantity) 
            : base(quantity)
        {
        }
    }
}

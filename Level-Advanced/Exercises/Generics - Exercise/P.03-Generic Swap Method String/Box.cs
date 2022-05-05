using System;
using System.Collections.Generic;
using System.Text;

namespace P._03_Generic_Swap_Method_String
{
    public class Box<T>
    {
        private T element;

        public T Element
        {
            get { return this.element; }
            set { this.element = value; }
        }
        public override string ToString()
        {
            return $"{this.Element.GetType().FullName}: {this.Element}";
        }
    }
}

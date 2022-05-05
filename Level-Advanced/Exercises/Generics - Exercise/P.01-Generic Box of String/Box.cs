using System;
using System.Collections.Generic;
using System.Text;

namespace P._01_Generic_Box_of_String
{
    public class Box<T>
    {
        private T boxElement;

        public T BoxElement
        {
            get { return this.boxElement; }
            set { this.boxElement = value; }
        }

        public override string ToString()
        {
            return $"{this.BoxElement.GetType().FullName}: {this.BoxElement}";
        }
    }
}

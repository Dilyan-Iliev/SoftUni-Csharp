using System;
using System.Collections.Generic;
using System.Text;

namespace P._02_Generic_Box_of_Integer
{
    public class Box<T>
    {
        private T elementToAdd;

        public T ElementToAdd
        {
            get { return this.elementToAdd; }
            set { this.elementToAdd = value; }
        }

        public override string ToString()
        {
            return $"{this.ElementToAdd.GetType().FullName}: {this.ElementToAdd}";
        }
    }
}

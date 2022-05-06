using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_Generic_Count_Method_String
{
    public class Box<T>
        where T : IComparable<T>
    {
        private T element;

        public T Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public int Compare(T element)
        {//create a method which will be used later

            return this.Element.CompareTo(element);
        }
    }
}

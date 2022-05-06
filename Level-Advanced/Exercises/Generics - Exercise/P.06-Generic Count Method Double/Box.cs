using System;
using System.Collections.Generic;
using System.Text;

namespace P._06_Generic_Count_Method_Double
{
    public class Box<T>
        where T : IComparable<T>
    {
        private T element;
        public T Element
        {
            get { return element; }
            set { element = value; }
        }

        public int Compare(T element)
        {
            return this.Element.CompareTo(element);
        }
    }
}

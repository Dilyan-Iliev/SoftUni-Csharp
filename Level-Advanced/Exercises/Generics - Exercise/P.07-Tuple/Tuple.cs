using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Tuple
{
    public class MyTuple<T1, T2>
    {
        private T1 firstParam;
        private T2 secondParam;

        public T1 FirstItem
        {
            get { return firstParam; }
            set { firstParam = value; }
        }
        public T2 SecondItem
        {
            get { return secondParam; }
            set { secondParam = value; }
        }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem}";
        }
    }
}

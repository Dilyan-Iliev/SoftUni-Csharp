using System;
using System.Collections.Generic;
using System.Text;

namespace P._08_Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        private T1 firstParam;
        private T2 secondParam;
        private T3 thirdParam;

        public T1 FirstParam
        {
            get { return firstParam; }
            set { firstParam = value; }
        }
        public T2 SecondParam
        {
            get { return secondParam; }
            set { secondParam = value; }
        }
        public T3 ThirdParam
        {
            get { return thirdParam; }
            set { thirdParam = value; }
        }

        public override string ToString()
        {
            return $"{this.FirstParam} -> {this.SecondParam} -> {this.ThirdParam}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
        //where T : struct or where T : class depending on the restrictions we need
    {
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        private T left;
        private T right;

        public T Left
        {
            get { return this.left; }
            set { this.left = value; }
        }
        public T Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public bool AreEqual()
        {
            return this.Right.Equals(this.Left);
        }
    }
}

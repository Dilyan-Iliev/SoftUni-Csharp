using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_StackOfStrings
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> collectionToInsert)
        {
            foreach (var element in collectionToInsert)
            {
                this.Push(element);
            }

            return this;
        }
    }
}

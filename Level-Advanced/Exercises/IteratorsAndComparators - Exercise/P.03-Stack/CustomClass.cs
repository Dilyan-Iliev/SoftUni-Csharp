using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P._03_Stack
{
    public class CustomClass<T> : IEnumerable<T>
    {
        public CustomClass(params T[] elements)
        {
            this.list = new List<T>();
            this.index = -1;
        }
        private int index;
        private List<T> list;

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                index++;
                list.Insert(index, element);
            }
        }
        public void Pop()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                list.RemoveAt(index);
            }
            index--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

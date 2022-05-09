using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P._02_Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(params T[] parameters)
        {
            this.list = new List<T>(parameters);
            this.index = 0;
        }
        private int index;
        private List<T> list;

        public bool Move()
        {

            if (index < list.Count - 1)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasNext()
        {
            if (index + 1 < list.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", list));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
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

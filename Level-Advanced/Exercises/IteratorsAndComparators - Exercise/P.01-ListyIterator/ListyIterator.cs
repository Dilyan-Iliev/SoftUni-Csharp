using System;
using System.Collections.Generic;
using System.Text;

namespace P._01_ListyIterator
{
    public class ListyIterator<T>
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
            
            if (index < list.Count-1)
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
    }
}

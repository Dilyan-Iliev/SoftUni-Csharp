using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListList___Implementation
{
    public class LinkedListItem<T>
    {
        public LinkedListItem(T value)
        {
            this.Value = value;
        }
        public LinkedListItem<T> Previous { get; set; }//this will be the previous element at the linked list
        public LinkedListItem<T> Next { get; set; }//this will be the next element at the linked list
        public T Value { get; set; }//this will be the element's value
    }
}

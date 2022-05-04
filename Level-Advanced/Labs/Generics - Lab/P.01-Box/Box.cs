using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            this.List = new List<T>();
        }
        private T item;
        private List<T> list;

        public T Item
        {
            get { return this.item; }
            set { this.item = value; }
        }
        public List<T> List
        {
            get { return this.list; }
            set { this.list = value; }
        }
        public int Count => this.list.Count;
        
        public void Add(T element)
        {
            this.List.Add(element);
        }
        public T Remove()
        {
            T elementToRemove = this.List[List.Count - 1];
            List.Remove(elementToRemove);
            return elementToRemove;
        }

    }
}

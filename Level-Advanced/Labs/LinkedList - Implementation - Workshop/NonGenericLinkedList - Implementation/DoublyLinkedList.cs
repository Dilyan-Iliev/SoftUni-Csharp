using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericLinkedList___Implementation
{
    public class DoublyLinkedList
    {
        private LinkedListItem first = null;//this is the default value
        private LinkedListItem last = null; //this is the default value

        //public int Count { get; private set; } //anyone can read it, no one could set value

        //or
        public int Count //Read-only property (only get)
        {
            get
            {
                var count = 0;

                var current = first;
                while (current != null)
                {//while we have elements

                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public void AddFirst(int element)
        {//adds an element at the beginning of the collection

            var newItem = new LinkedListItem(element);
            if (first == null)
            {//when we dont have any elements

                first = newItem;
                last = newItem;
            }
            else
            {//when we have any item

                newItem.Next = first; //следващия елемент е равен на предишния първи 
                first.Previous = newItem; //предишния елемент на предишния първи е равен на новия елемент

                first = newItem; //първия елемент е равен на новия елемент
            }

            //Count++;
        }
        public void AddLast(int element)
        {//adds an element at the end of the collection

            //same logic as AddFirst()
            var newElement = new LinkedListItem(element);
            if (last == null)
            {
                first = newElement;
                last = newElement;
            }
            else
            {
                last.Next = newElement;
                newElement.Previous = last;
                last = newElement;
            }

            //Count++;
        }
        public int RemoveFirst()
        {//removes the element at the beginning of the collection

            if (first == null)
            {//0 items

                throw new InvalidOperationException("Linked list empty!");
                //this exception will end the program
            }

            var currentFirstValue = first.Value; //this will be the removed element
            if (first == last)
            {//1 item 

                first = null;
                last = null;
            }
            else
            {//more than 1 item

                var newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }

            //Count--;
            return currentFirstValue;
        }
        public int RemoveLast()
        {//removes the element at the end of the collection

            //same logic as RemoveFirst()

            if (last == null)
            {
                throw new InvalidOperationException("Linked list empty!");
                //this exception will end the program
            }

            var currentLastValue = last.Value;
            if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }

            // Count--;
            return currentLastValue;
        }
        public void ForEach(Action<int> action)
        {//goes through the collection and executes a given action

            var currentElement = first;
            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.Next;
            }
        }
        public int[] ToArray()
        {//returns the collection as an array

            var array = new int[Count];
            var index = 0;

            var current = first;
            while (current != null)
            {
                array[index] = current.Value;
                index++;
                current = current.Next;
            }

            return array;
        }
    }
}

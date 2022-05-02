using System;

namespace GenericListList___Implementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var listt = new DoublyLinkedList<int>();
            //listt.RemoveFirst();

            var stringList = new DoublyLinkedList<string>();
            stringList.AddFirst("George");

            var list = new DoublyLinkedList<int>();
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddFirst(0);
            list.AddLast(100);
            //0-1-2-3-4-100
            list.RemoveFirst();
            //1-2-3-4-100;
            list.RemoveLast();
            //1-2-3-4
            list.AddLast(5);
            //1-2-3-4-5
            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(", ", list.ToArray()));
            //1, 2, 3, 4, 5

            list.ForEach(PrintToConsole);
        }

        static void PrintToConsole(int i)
        {
            Console.WriteLine(i);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonGenericLinkedList___Implementation
{
    public class LinkedListItem
    {
        public LinkedListItem(int value)
        {
            this.Value = value;
        }
        public LinkedListItem Previous { get; set; }//това ще е предишния елемент в свързания списък
        public LinkedListItem Next { get; set; }//това ще е следващия елемент в свързания списък
        public int Value { get; set; }//това ще е стойността на даден елемент
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P._04_RandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }
        public string RandomString()
        {
            string element = random.Next(0, this.Count).ToString();

            return element;
        }
        public string RemoveElement()
        {
            var index = random.Next(0, this.Count);
            string element = this[index];

            this.RemoveAt(index);

            return element;
        }
    }
}

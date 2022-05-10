using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P._04_Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(int[] stones)
        {
            this.PathOfStones = stones;
        }
        private int[] pathOfStones;

        public int[] PathOfStones
        {
            get { return pathOfStones; }
            set { pathOfStones = value; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < pathOfStones.Length; i+=2)
            {
                yield return pathOfStones[i];
            }


            int startingReversedIndex = 0;

            if (pathOfStones.Length % 2 == 0)
            {
                startingReversedIndex = pathOfStones.Length - 1;
            }
            else
            {
                startingReversedIndex = pathOfStones.Length - 2;
            }

            for (int i = startingReversedIndex; i > 0; i-=2)
            {
                yield return pathOfStones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

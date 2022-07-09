using System.Linq;
using System.Collections.Generic;
using PracticeForJudge.Models.Interfaces;

namespace PracticeForJudge.Models
{
    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> collection;

        public MyList()
        {
            collection = new List<T>();
        }

        public int Used => collection.Count;

        public int Add(T item)
        {
            collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T item = collection.FirstOrDefault();

            if (item != null)
            {
                collection.Remove(item);
            }

            return item;
        }
    }
}

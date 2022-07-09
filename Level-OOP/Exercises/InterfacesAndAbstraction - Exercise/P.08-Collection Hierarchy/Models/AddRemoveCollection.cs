using System.Linq;
using System.Collections.Generic;
using PracticeForJudge.Models.Interfaces;

namespace PracticeForJudge.Models
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> collection;

        public AddRemoveCollection()
        {
            collection = new List<T>();
        }

        public int Add(T item)
        {
            collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T item = collection.LastOrDefault();

            if (item != null)
            {
                collection.Remove(item);
            }

            return item;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;
        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);
            this.currentIndex = -1;
        }
        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            this.currentIndex++;
            if (this.currentIndex < this.books.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}

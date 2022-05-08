using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P._02_Library_Iterator
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P._02_Library_Iterator
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
        private List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < books.Count; i++)
            {
                yield return books[i];
            }
            //or
           // return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

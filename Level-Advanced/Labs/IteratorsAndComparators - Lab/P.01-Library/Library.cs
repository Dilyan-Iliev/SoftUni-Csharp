using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P._01_Library
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books); 
        }
        private List<Book> books { get; set; }

        public void AddBook(Book book)
        {
            this.books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            this.books.Remove(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //return new LibraryIterator(this.books);

            //or
            //with yield return :

            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i]; //това генерира скришом специален клас, който изглежда почти като моя LibraryIterator
                //т.е. на всяка итерация на нашия цикъл връщаме елемент от списъка, който отива във foreach-a
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

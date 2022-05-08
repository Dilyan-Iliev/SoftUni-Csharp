using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P._01_Library
{
    class LibraryIterator : IEnumerator<Book>
    {
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            this.index = -1; 
        }
        private List<Book> books;
        private int index;

        public Book Current => this.books[index];  //2ри се извиква този метод
        //когато вече имаме някакъв индекс , Current ще връща книгата от списъка с книги на текущия индекс

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext() //1во се извиква този метод, поради това сме сложили index = -1, понеже тук той ще стане 0
        {
            index++;//т.е. ще местя индекса надясно и след това ще проверявам дали има още книги 

            if (index < this.books.Count)
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
            this.index = -1;
        }
    }
}

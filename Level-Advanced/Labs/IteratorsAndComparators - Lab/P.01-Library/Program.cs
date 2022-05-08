using System;
using System.Collections.Generic;

namespace P._01_Library
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Library firstLibrary = new Library();
            
            //Book firstBook = new Book("Matrix", 2005, new List<string>() { "Sam", "George"}); //така се създава без params
            //firstLibrary.AddBook(firstBook);

            //Book paramsBook = new Book("Lord of the rings", 2006, "Petur", "Dimitur", "Nikolay");//така се създава с params

            //Book secondBook = new Book("Harry Potter", 2007, new List<string>() { "J.K.Rolling" });
            //firstLibrary.AddBook(secondBook);

            //foreach (Book book in firstLibrary)
            //{
            //    Console.WriteLine(book.Year);
            //    Console.WriteLine(book.Title);
            //    Console.WriteLine(string.Join(" ", book.Authors));
            //}

            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

        }
    }
}

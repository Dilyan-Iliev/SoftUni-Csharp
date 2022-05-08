using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P._01_Library
{
    public class Book
    {
        public Book(string title, int year, params string[] autors) // or List<string> authors
        {
            this.Title = title;
            this.Year = year;
            this.Authors = autors.ToList();
        }
        public string Title { get; set; }
        public int  Year { get; set; }
        public List<string> Authors { get; set; }
    }
}

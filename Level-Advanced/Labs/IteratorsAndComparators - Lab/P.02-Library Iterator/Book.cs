using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P._02_Library_Iterator
{
    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        private string title;
        private int year;
        private List<string> authors;

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public List<string> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
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

        public int CompareTo(Book other)
        {
            if (this.Year.CompareTo(other.Year) > 0)
            {
                return 1;
            }
            else if (this.Year.CompareTo(other.Year) < 0)
            {
                return -1;
            }
            else // if this.Year.CompareTo(other.Year) == 0)
            {
                if (this.Title.CompareTo(other.Title) > 0)
                {
                    return 1;
                }
                else if (this.Title.CompareTo(other.Title) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Article> data = new List<Article>();
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            var currentArticle = new Article(list[0], list[1], list[2]);
            //currentArticle.Title = list[0];
            //currentArticle.Content = list[1];
            //currentArticle.Author = list[2];
            for (int i = 1; i <= numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArgs = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCommand = cmdArgs[0];
                if (currentCommand == "Edit")
                {
                    string newContent = cmdArgs[1];
                    currentArticle.Edit(newContent);
                }
                else if (currentCommand == "ChangeAuthor")
                {
                    string newAuthor = cmdArgs[1];
                    currentArticle.ChangeAuthor(newAuthor);
                }
                else if (currentCommand == "Rename")
                {
                    string newTitle = cmdArgs[1];
                    currentArticle.ChangeTitle(newTitle);
                }
                
            }
            Console.WriteLine(currentArticle.ToString());
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public void Edit (string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor (string newAuthor)
        {
            Author = newAuthor;
        }

        public void ChangeTitle (string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

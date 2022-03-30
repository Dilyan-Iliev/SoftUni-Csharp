using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> listOfArticles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfArticles; i++)
            {
                string[] articles = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string title = articles[0];
                string content = articles[1];
                string author = articles[2];

                var article = new Article(title, content, author);
                listOfArticles.Add(article);
            }

            string criteriaForOrdering = Console.ReadLine();

            List<Article> orderedArticles = null;

            switch (criteriaForOrdering)
            {
                case "title":
                    orderedArticles = listOfArticles
              .OrderBy(article => article.Title)
              .ToList();
                    break;
                case "content":
                    orderedArticles = listOfArticles
            .OrderBy(article => article.Content)
            .ToList();
                    break;
                case "author":
                    orderedArticles = listOfArticles
             .OrderBy(article => article.Author)
             .ToList();
                    break;
            }

            Console.WriteLine(string.Join(Environment.NewLine, orderedArticles));
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

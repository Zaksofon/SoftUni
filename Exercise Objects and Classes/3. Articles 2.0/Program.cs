using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Articles_2._0
{
    class Program
    {
        public class Article
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


            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());

                Article article = null;

                IList<Article> articles = new List<Article>();

                for (int i = 0; i < n; i++)
                {
                    string[] input = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                    string newTitle = input[0];
                    string newContent = input[1];
                    string newAuthor = input[2];

                    article = new Article(newTitle, newContent, newAuthor);
                    articles.Add(article);
                }

                IList<Article> sorted = default;

                string sortingCriteria = Console.ReadLine();

                switch (sortingCriteria)
                {
                    case "title": sorted = articles.OrderBy(t => t.Title).ToList(); break;

                    case "content": sorted = articles.OrderBy(c => c.Content).ToList(); break;

                    case "author": sorted = articles.OrderBy(a => a.Author).ToList(); break;
                }

                foreach (var element in sorted)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}

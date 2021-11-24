using System;
using System.Linq;

namespace _2._Articles
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


                public void Edit(string newContent) => Content = newContent;

                public void ChangeAuthor(string newAuthor) => Author = newAuthor;

                public void Rename(string newName) => Title = newName;

                public override string ToString()
                {
                    return $"{Title} - {Content}: {Author}";
                }
        }


        static void Main(string[] args)
        {
            string[] content = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(content[0], content[1], content[2]);

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string newContent = parts[1];

                switch (command)
                {
                    case "Edit": article.Edit(newContent); break;

                    case "ChangeAuthor": article.ChangeAuthor(newContent); break;

                    case "Rename": article.Rename(newContent); break;
                }
            }

            Console.WriteLine(article);
        }
    }
}

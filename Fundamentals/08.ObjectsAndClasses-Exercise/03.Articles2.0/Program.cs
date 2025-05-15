using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;


namespace _03.Articles2._0
{
    class Article
    {
        public string Title;
        public string Content;
        public string Author;

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Article> articlesList = new List<Article>();

            for (int i = 1; i <= number; i++)
            {
                string[] inputArray = Console.ReadLine().Split(", ");
                string title = inputArray[0];
                string content = inputArray[1];
                string author = inputArray[2];

                articlesList.Add(new Article(title, content, author));
            }

            foreach (var article in articlesList)
            {
                Console.WriteLine(article);
            }
        }
    }
}

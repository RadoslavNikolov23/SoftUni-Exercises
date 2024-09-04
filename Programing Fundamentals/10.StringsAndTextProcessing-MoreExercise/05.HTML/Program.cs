using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();
            string contentofArtichle = Console.ReadLine();
            string commentsofArticle;
            List<string> commentsArticleList = new List<string>();

            while((commentsofArticle=Console.ReadLine())!= "end of comments")
            {
                commentsArticleList.Add(commentsofArticle);
            }

            PrintHTMLStyle(titleOfArticle, contentofArtichle, commentsArticleList);

        }

        private static void PrintHTMLStyle(string titleOfArticle, string contentofArtichle, List<string> commentsArticleList)
        {
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {titleOfArticle}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"    {contentofArtichle}");
            Console.WriteLine("</article>");
            foreach (var comment in commentsArticleList)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"    {comment}");
                Console.WriteLine("</div>");

            }

        }
    }
}

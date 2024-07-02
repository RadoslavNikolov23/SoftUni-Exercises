

namespace _02.Articles
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

        public void EditContent(string content)
        {
            Content= content;
        }  
        
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void RenameTitle(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] articleArray = Console.ReadLine().Split(", ");
            string title = articleArray[0];
            string content = articleArray[1];
            string author = articleArray[2];

            Article article = new Article(title, content, author);

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(": ");

                switch (commands[0])
                {
                    case "Edit":
                        article.EditContent(commands[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(commands[1]);
                        break;
                    case "Rename":
                        article.RenameTitle(commands[1]);
                        break;
                }

            }
            Console.WriteLine(article.ToString());


        }
    }
}

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                char star = '*';
                string newTemp=new string(star, bannedWords[i].Length);
                text = text.Replace(bannedWords[i], newTemp);
            }

            Console.WriteLine(text);

        }
    }
}

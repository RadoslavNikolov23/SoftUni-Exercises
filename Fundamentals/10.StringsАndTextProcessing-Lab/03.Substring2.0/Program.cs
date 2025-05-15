namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();
            string line = Console.ReadLine();
            bool isTrue = line.Contains(word);

            while (isTrue)
            {

                int index = line.IndexOf(word);
                line = line.Remove(index, word.Length);
                isTrue = line.Contains(word);
            }

            Console.WriteLine(line);
        }
    }
}
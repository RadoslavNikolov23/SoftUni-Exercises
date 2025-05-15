namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Console.WriteLine(CountVowels(input));
        }

        static int CountVowels(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'i' || input[i] == 'e' || input[i] == 'o' || input[i] == 'y' ||
                    input[i] == 'u' || input[i] == 'A' || input[i] == 'I' || input[i] == 'E' || input[i] == 'O' ||
                    input[i] == 'Y' || input[i] == 'U')
                {
                    count++;
                }
            }

            if (count > 0)
            {
                return count;
            }
            else
            {
                return count;
            }
        }
    }
}
namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string temp = input;

                temp = ReverseString(temp);
                Console.WriteLine($"{input} = {temp}");
            }
        }

        public static string? ReverseString(string? temp)
        {
            char[] charArray = temp.ToCharArray();
            Array.Reverse(charArray);
            temp = charArray.ToString();
            return new string(charArray);
        }
    }
}

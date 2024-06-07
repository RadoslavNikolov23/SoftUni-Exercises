namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are given an input of two values of the same type. The values can be of type int, char or string.
            //    Create methods called GetMax(), which can compare int, char or string and returns the biggest of the two values.

            string input = Console.ReadLine();


            if (input == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
               
            }
            else if (input == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));

            }
            else if (input == "string")
            {
                string a = Console.ReadLine();
               string  b = Console.ReadLine();
               Console.WriteLine(GetMax(a, b));
            }





        }
        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}

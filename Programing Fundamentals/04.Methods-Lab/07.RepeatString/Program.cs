namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	A string
            //    •	A number n(integer) represents how many times the string will be repeated
            //The method should return a new string, containing the initial one, repeated n times without space. 

            string input = Console.ReadLine();
            int numberOfRepeates = int.Parse(Console.ReadLine());

            Console.WriteLine(NewString(input, numberOfRepeates));

            static string NewString(string input, int number)
            {
                string newString = null;
                for (int i = 0; i < number; i++)
                {
                    newString += input;
                }

                return newString;
            }



        }
    }
}

namespace _02.EnterNumbers
{
    public class Program
    {
        static void Main()
        {
            ReadNumber(1, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            List<int> numbers = new List<int>();

            int lastNumber = 1;

            while (numbers.Count < 10)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int number))
                        throw new FormatException("Invalid Number!");

                    if (number <= lastNumber || number >= end)
                        throw new ArgumentOutOfRangeException($"Your number is not in range {lastNumber} - 100!");

                    numbers.Add(number);
                    lastNumber = number;

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}

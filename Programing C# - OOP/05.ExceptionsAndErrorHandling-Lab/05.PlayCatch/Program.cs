namespace _05.PlayCatch
{
    public class Program
    {
        static void Main()
        {

            int[] arrayInt=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int count = 0;

            while (count < 3)
            {
                string[] input = Console.ReadLine().Split(" ");
                string command = input[0];

                try
                {
                    ChechCommand(arrayInt, input, command);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    count++;
                }                
                catch(ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("The index does not exist!");
                    count++;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("The index does not exist!");
                    count++;
                }
            }

            Console.WriteLine(string.Join(", ", arrayInt));
        }

        private static void ChechCommand(int[] arrayInt, string[] input, string command)
        {
            switch (command)
            {
                case "Replace":
                    int indexReplace = int.Parse(input[1]);
                    int elementReplace = int.Parse(input[2]);
                    arrayInt[indexReplace] = elementReplace;
                    break;
                case "Print":
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2])+1;
                    Console.WriteLine(string.Join(", ", arrayInt[startIndex..endIndex]));

                    break;
                case "Show":
                    int indexShow = int.Parse(input[1]);
                    Console.WriteLine(arrayInt[indexShow]);
                    break;
            }
        }
    }
}

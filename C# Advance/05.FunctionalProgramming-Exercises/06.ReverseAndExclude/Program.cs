using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());


            Func<List<int>, Predicate<int>, List<int>> reverseCollection = Reverse;
            Predicate<int> isDivisible = x => x % divider == 0 ? true : false;

            Console.WriteLine(string.Join(" ", reverseCollection(listNumbers, isDivisible)));


            List<int> Reverse(List<int> listNumbers, Predicate<int> isDivisible)
            {
                List<int> reversedList = new List<int>();

                for (int i = listNumbers.Count - 1; i >= 0; i--)
                {
                    if (!isDivisible(listNumbers[i]))
                        reversedList.Add(listNumbers[i]);
                }

                return reversedList;
            }

        }
    }
}

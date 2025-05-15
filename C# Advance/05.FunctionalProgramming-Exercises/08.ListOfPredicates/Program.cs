using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMax = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            List<int> divisibleNumbers = new List<int>();
            int lenghDividers = dividers.Length;

            Func<int, int, bool> isDivisable = (x, y) => x % y == 0;
            Predicate<int> isEnought = x => x < lenghDividers;

            for (int i = 1; i <= numberMax; i++)
            {
                int j = 0;
                bool isDivisible = true;
                while (isEnought(j))
                {
                    if (isDivisable(i, dividers[j]))
                    {
                        isDivisible = true;
                    }
                    else
                    {
                        isDivisible = false;
                        break;
                    }

                    j++;
                }

                if (isDivisible) divisibleNumbers.Add(i);
            }
            Console.WriteLine(string.Join(" ", divisibleNumbers));

        }
    }
}

/*Alternative:
 * 
 * 
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMax = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            List<int> divisibleNumbers = new List<int>();
            int lenghDividers = dividers.Length;

            Func<int, int, bool> isDivisable = (x, y) => x % y == 0;
            Predicate<int> isEnought = x => x < lenghDividers;

            bool isDivisible = true;
            for (int i = 1; i <= numberMax; i++)
            {

                foreach (var divider in dividers)
                {

                    if (!isDivisable(i, divider))
                    {
                        isDivisible = false;
                        break;
                    }
                  
                }

                if (isDivisible) divisibleNumbers.Add(i);
                
                isDivisible = true;

            }
            Console.WriteLine(string.Join(" ", divisibleNumbers));

        }
    }
}

 */

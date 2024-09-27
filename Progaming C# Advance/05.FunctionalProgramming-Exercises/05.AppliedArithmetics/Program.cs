using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            Func<List<int>, List<int>> appliedArithmetics = ArithmeticsMethod;

            appliedArithmetics(numbers);


            List<int> ArithmeticsMethod(List<int> numbers)
            {
                Func<int, int> add = x => x += 1;
                Func<int, int> multiply = x => x *= 2;
                Func<int, int> subtract = x => x -= 1;
                Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

                string command;
                while ((command = Console.ReadLine()) != "end")
                {
                    switch (command)
                    {
                        case "add":
                            numbers = numbers.Select(x => add(x)).ToList();
                            break;
                        case "multiply":
                            numbers = numbers.Select(x => multiply(x)).ToList();
                            break;
                        case "subtract":
                            numbers = numbers.Select(x => subtract(x)).ToList();
                            break;
                        case "print":
                            print(numbers);
                            break;
                    }


                }
                return numbers;
            }
        }
    }
}

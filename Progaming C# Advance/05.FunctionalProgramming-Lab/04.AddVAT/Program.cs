using System;
using System.Linq;


namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Variant
            Func<double, string> addVat = x => $"{x += (x * 0.2):f2}";

            Console.WriteLine(string.Join('\n', Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat))); 
            

            //Second variant:
           /* Console.WriteLine(string.Join('\n', Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x=>$"{x += (x * 0.2):f2}")));

            */
        }
    }
}

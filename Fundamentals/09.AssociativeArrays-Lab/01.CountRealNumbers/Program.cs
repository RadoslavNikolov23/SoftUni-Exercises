namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers=Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double,double> counDictionary=new SortedDictionary<double,double>();

            foreach (double number in numbers)
            {
                if (!counDictionary.ContainsKey(number))
                {
                    counDictionary.Add(number, 0);
                }

                counDictionary[number]++;
            }

            foreach (var number in counDictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }


        }
    }
}

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<double> numbersList=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

            Dictionary<double,int>countDictionary=new Dictionary<double,int>();

            foreach (double number in numbersList)
            {
                if (!countDictionary.ContainsKey(number))
                {
                    countDictionary.Add(number, 0);
                }

                countDictionary[number]++;
            }

            foreach (var pair in countDictionary)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string textInput=Console.ReadLine();
            Dictionary<char,int> countSymbol= new Dictionary<char,int>();

            for(int i=0;i<textInput.Length;i++)
            {
                char temp=textInput[i];

                if (!countSymbol.ContainsKey(temp))
                {
                    countSymbol.Add(temp,0);
                    countSymbol[temp]++;
                }
                else
                {
                    countSymbol[temp]++;
                }
            }

            foreach (var (symbol, times) in countSymbol.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol}: {times} time/s");
            }
        }
    }
}

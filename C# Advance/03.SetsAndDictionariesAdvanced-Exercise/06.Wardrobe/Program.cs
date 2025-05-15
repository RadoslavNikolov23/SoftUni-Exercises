namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobeDT = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] array = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = array[0];
                string[] clothes = array[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobeDT.ContainsKey(color))
                {
                    wardrobeDT.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobeDT[color].ContainsKey(clothes[j]))
                    {
                        wardrobeDT[color].Add(clothes[j], 1);
                    }
                    else
                    {
                        wardrobeDT[color][clothes[j]]++;
                    }
                }
            }

            string[] itemToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string itemColor = itemToFind[0];
            string itemSet = itemToFind[1];


            foreach (var (color, items) in wardrobeDT)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (item, coutTimes) in items)
                {
                    if (color == itemColor && itemSet == item)
                    {
                        Console.WriteLine($"* {item} - {coutTimes} (found!)");

                    }
                    else
                    {
                        Console.WriteLine($"* {item} - {coutTimes}");

                    }
                }
            }

        }
    }
}

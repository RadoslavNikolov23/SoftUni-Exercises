namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] univers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int row = int.Parse(Console.ReadLine());

            int[][] sets = new int[row][];

            for (int i = 0; i < row; i++)
            {
                int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sets[i] = new int[data.Length];

                for (int j = 0; j < data.Length; j++)
                {
                    sets[i][j] = data[j];
                }

            }

            List<int[]> selectedSets = ChooseSets(sets.ToList(), univers.ToList());


            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach(int[] set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] longestSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x))).FirstOrDefault();

                selectedSets.Add(longestSet);
                sets.Remove(longestSet);

                for(int i = 0;i < longestSet.Length;i++) 
                universe.Remove(longestSet[i]);


            }
            return selectedSets;
        }
    }
}

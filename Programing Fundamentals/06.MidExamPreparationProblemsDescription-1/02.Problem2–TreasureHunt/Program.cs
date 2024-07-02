using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Problem2_TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> chest = Console.ReadLine().Split("|").ToList();
            string input;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] inputArray = input.Split();
                switch (inputArray[0])
                {
                    case "Loot":
                        List<string> lootItems = new List<string>(inputArray);
                        lootItems.RemoveAt(0);
                        chest = LootItems(chest, lootItems);
                        break;

                    case "Drop":
                        int dropIndex = int.Parse(inputArray[1]);
                        chest = DropChest(chest, dropIndex);
                        break;

                    case "Steal":
                        int stealCount = int.Parse(inputArray[1]);
                        chest = StealCount(chest, stealCount);
                        break;
                }
            }

            int sumAllTreasureItems = 0;
            foreach (var item in chest)
            {
                sumAllTreasureItems += item.Length;
            }

            double avatageTreasureGain = (double)sumAllTreasureItems / chest.Count;

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {avatageTreasureGain:f2} pirate credits.");
            }




        }

        static List<string> LootItems(List<string> chest, List<string> lootItems)
        {

            //•	"Loot {item1} {item2}…{itemn}":
            //o Pick up treasure loot along the way. Insert the items at the beginning of the chest.
            //o If an item is already contained, don't insert it.

            for (int i = 0; i < lootItems.Count; i++)
            {
                if (!chest.Contains(lootItems[i]))
                {
                    chest.Insert(0, lootItems[i]);
                }
            }
            return chest;
        }

        static List<string> DropChest(List<string> chest, int dropIndex)
        {
            if (!CheckIndex(chest, dropIndex))
            {
                return chest;
            }
            string temp = chest[dropIndex];
            chest.RemoveAt(dropIndex);
            chest.Add(temp);
            //•	"Drop {index}":
            //o Remove the loot at the given position and add it at the end of the treasure chest. 
            //o If the index is invalid, skip the command.

            return chest;
        }
         static List<string> StealCount(List<string> chest, int stealCount)
        {
            List<string> tempList = new List<string>();
            if (stealCount >= chest.Count)
            {
                stealCount = chest.Count;
            }
            tempList = chest.GetRange(chest.Count - stealCount, stealCount);
            chest.RemoveRange(chest.Count - stealCount, stealCount);
            Console.WriteLine(string.Join(", ",tempList));

            //•	"Steal {count}":
            //o Someone steals the last count loot items.
            //If there are fewer items than the given count, remove as much as there are.
            //o Print the stolen items separated by ", ":
            //"{item1}, {item2}, {item3} … {itemn}"

            return chest;
        }


         static bool CheckIndex(List<string> chest, int dropIndex)
        {
            if(dropIndex<0 || dropIndex >= chest.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

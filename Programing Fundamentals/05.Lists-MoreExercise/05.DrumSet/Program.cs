using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal savings = decimal.Parse(Console.ReadLine());
            //List<int> qualityList = Console.ReadLine().
            //                                   Split().
            //                                   Select(int.Parse).
            //                                   ToList();

            int[] qualityArray = Console.ReadLine().
                                               Split().
                                               Select(int.Parse).
                                               ToArray();

            List<int> drumList = qualityArray.ToList();
            string input;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drumList.Count; i++)
                {
                    if (drumList[i] > 0)
                    {
                        drumList[i] -= hitPower;

                        if (drumList[i] <= 0)
                        {
                            if (savings <= 0 || (qualityArray[i] * 3)>savings)
                            {
                                continue;
                            }
                            else
                            {
                                drumList[i] = qualityArray[i];
                                savings -= (qualityArray[i] * 3);
                            }

                        }
                    }


                }


            }

            List<int> finalDrumList = new List<int>();
            drumList.ForEach(drum =>
            {
                if (drum > 0)
                    finalDrumList.Add(drum);
            }
            );

            Console.WriteLine(string.Join(" ", finalDrumList));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");

        }
    }
}

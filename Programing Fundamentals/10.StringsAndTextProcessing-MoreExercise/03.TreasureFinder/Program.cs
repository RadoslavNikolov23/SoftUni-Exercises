using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lenghKey = key.Length;
            string input;
            List<string[]> listCord = new List<string[]>();

            while ((input = Console.ReadLine()) != "find")
            {
                string tempSt = string.Empty;
                int cout = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    char tempC = input[i];
                    tempSt += (char)(tempC - key[cout++]);

                    if (cout == key.Length)
                    {
                        cout = 0;
                    }

                }
                Console.WriteLine(tempSt);

                int[] indexType = new int[2];
                int[] indexCord = new int[2];
                int coutType = 0;

                for (int i = 0; i < tempSt.Length; i++)
                {
                    char tempCh = tempSt[i];

                    if (tempCh == '&')
                    {
                        indexType[coutType++]=i;
                    }

                    if (tempCh == '<')
                    {
                        indexCord[0]=i;
                    }

                    if (tempCh == '>')
                    {
                        indexCord[1]=i;
                    }

                }

                string type = tempSt.Substring(indexType[0]+1,indexType[1]-indexType[0]-1);
                string cordinates = tempSt.Substring(indexCord[0] + 1, indexCord[1] - indexCord[0] - 1);


                listCord.Add(new string[] { type, cordinates });


                /*
                 *you will get a type of treasure and its coordinates.
                 *The type will be between the symbol '&' and the coordinates will be between the symbols '<' and '>'. 
                 *For each line, print the type and the coordinates in format "Found {type} at {coordinates}".
                 */
            }

            foreach (var treasure in listCord)
            {
                Console.WriteLine($"Found {treasure[0]} at {treasure[1]}");
            }
        }
    }
}

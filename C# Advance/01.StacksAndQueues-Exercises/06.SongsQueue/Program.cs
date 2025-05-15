using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(", ");
            Queue<string> songQU = new Queue<string>(array);

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                string firstCommand = command[0];

                switch (firstCommand)
                {
                    case "Play":
                        songQU.Dequeue();
                        break;

                    case "Add":
                        string songName = command[1];
                        for (int i = 2; i < command.Length; i++)
                        {
                            songName += $" {command[i]}";
                        }
                        if (!songQU.Contains(songName))
                        {
                            songQU.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ",songQU));
                        break;
                }



                if (songQU.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

            }

        }
    }
}

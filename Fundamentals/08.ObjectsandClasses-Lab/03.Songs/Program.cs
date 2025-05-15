using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;


namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSongs = int.Parse(Console.ReadLine());
            List<Song> songList = new List<Song>();
         

            for (int i = 1; i <= numberSongs; i++)
            {
                string[] arraySong = Console.ReadLine().Split("_");
                string type = arraySong[0];
                string name = arraySong[1];
                string time = arraySong[2];

                Song song = new Song();
                song.typeList = type;
                song.name = name;
                song.time = time;

                songList.Add(song);
            }

            string typeOutpu = Console.ReadLine();

            if (typeOutpu == "all")
            {
                foreach (var item in songList)
                {
                    Console.WriteLine(item.name);
                }
            }
            else
            {
                foreach (var item in songList)
                {
                    if (item.typeList == typeOutpu)
                    {
                        Console.WriteLine(item.name);

                    }

                }

            }

        }


    }
    class Song
    {
        public string typeList;
        public string name;
        public string time;
    }
}

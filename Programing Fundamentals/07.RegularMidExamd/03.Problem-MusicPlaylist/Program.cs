namespace _03.Problem_MusicPlaylist
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> songList = Console.ReadLine().Split().ToList();
            int counter = int.Parse(Console.ReadLine());

            while (counter > 0)
            {
                string[] commandArray = Console.ReadLine().Split(" * ");


                switch (commandArray[0])
                {
                    case "Add Song":
                        string addSong = commandArray[1];
                        songList = AddSongToList(songList, addSong);
                        break;

                    case "Delete Song":
                        int numberDeleteSons = int.Parse(commandArray[1]);
                        songList = DeleteSonsFromList(songList, numberDeleteSons);
                        break;

                    case "Shuffle Songs":
                        int shuffleIndexOne = int.Parse(commandArray[1]);
                        int shuffleIndexTwo = int.Parse(commandArray[2]);
                        songList = ShuffleSonsOnList(songList, shuffleIndexOne, shuffleIndexTwo);
                        break;

                    case "Insert":
                        string insertSong = commandArray[1];
                        int insertAtIndex = int.Parse(commandArray[2]);
                        songList = InsertSongOnList(songList, insertSong, insertAtIndex);
                        break;

                    case "Sort":
                        songList = SortListInAlphabeticDescedingOrde(songList);
                        break;

                    case "Play":
                        PrintSongOnTheList(songList);
                        break;
                }

                counter--;
            }



        }

        private static void PrintSongOnTheList(List<string> songList)
        {
            Console.WriteLine("Songs to Play:");
            foreach (var song in songList)
            {
                Console.WriteLine(song);
            }
            //    o Print the playlist in the following format:
            //    " Songs to Play:
            //        { song1}
            //        { song2}
            //            …
            //        { songn}"
        }

        static List<string> SortListInAlphabeticDescedingOrde(List<string> songList)
        {
            // o Order the songs alphabetically in descending order.

            songList.Sort();
            songList.Reverse();
            return songList;
        }

        static List<string> InsertSongOnList(List<string> songList, string insertSong, int insertAtIndex)
        {
            if (insertAtIndex >= 0 && insertAtIndex < songList.Count)
            {
                if (songList.Contains(insertSong))
                {
                    Console.WriteLine("Song is already in the playlist");
                }
                else
                {
                    songList.Insert(insertAtIndex, insertSong);
                    Console.WriteLine($"{insertSong} successfully inserted");
                }
                //o Insert the song at the given index, only if the resulting index exists, and print: 
                //"{song} successfully inserted"

                //o If the index is in range, but the song is already in the list, print: 
                //"Song is already in the playlist"
            }
            else
            {
                Console.WriteLine("Index out of range");
                //o If the index is out of range, print: 
                //"Index out of range"
            }

            return songList;

        }

        static List<string> ShuffleSonsOnList(List<string> songList, int shuffleIndexOne, int shuffleIndexTwo)
        {
            if ((shuffleIndexOne >= 0 && shuffleIndexOne < songList.Count) &&
                (shuffleIndexTwo >= 0 && shuffleIndexTwo < songList.Count))
            {
                string tempSong = songList[shuffleIndexOne];
                songList[shuffleIndexOne] = songList[shuffleIndexTwo];
                songList[shuffleIndexTwo] = tempSong;
                Console.WriteLine($"{songList[shuffleIndexOne]} is swapped with {songList[shuffleIndexTwo]}");
            }
            return songList;
            //o If both of the song indexes exist in your list, swap the songs that are on those indexes.Print: 
            //"{new first song} is swapped with {new second song}"
            //    	Make sure to print the names of the songs after the songs are swapped.
            //o If one or both indexes are out of range, ignore the command.
        }

        static List<string> DeleteSonsFromList(List<string> songList, int numberDeleteSons)
        {
            List<string> deleteSongList = new List<string>();

            if (numberDeleteSons < songList.Count)
            {
                for (int i = 0; i < numberDeleteSons; i++)
                {
                    deleteSongList.Add(songList[0]);
                    songList.RemoveAt(0);
                }

                Console.WriteLine($"{string.Join(", ", deleteSongList)} deleted");
            }

            return songList;
            //o Remove the given number of songs from the beginning of the list and print:
            //"{song1}, … {songn} deleted"
            //o If you have fewer songs on your list than the given number, skip this command.

        }

        static List<string> AddSongToList(List<string> songList, string addSong)
        {
            //o Add a song at the last position of the playlist and print:
            //"{song} successfully added"
            //o If the song is already present on the list, ignore the command.
            if (songList.Contains(addSong))
            {
                return songList;
            }
            else
            {
                songList.Add(addSong);
                Console.WriteLine($"{addSong} successfully added");
                return songList;
            }

        }
    }
}

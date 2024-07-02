using System.Diagnostics.Metrics;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Create a program that keeps track of the guests that are going to a house party. 
            //    On the first line, of input you are going to receive the number of commands that will follow.
           
            //    On the next lines, you are going to receive some of the following:  "{name} is going!"
            //    •	You have to add the person, if they are not on the guestlist already.
            //    •	If the person is on the list print the following to the console: "{name} is already in the list!"
            //"{name} is not going!"
            //    •	You have to remove the person, if they are on the list. 
            //    •	If not, print out: "{name} is not in the list!"
            //Finally, print all of the guests, each on a new line.

            int numberComands = int.Parse(Console.ReadLine());
            List<string> nameList= new List<string>();
            int counter = 0;


            //while (counter >= numberComands)
            //{
            //    string[] arrayComand = Console.ReadLine().Split();

            //    if (arrayComand.Length < 4)
            //    {
            //        if (nameList.Exists(x => x == arrayComand[0]))
            //        {
            //            Console.WriteLine($"{arrayComand[0]} is already in the list!");
            //        }
            //        else
            //        {
            //            nameList.Add(arrayComand[0]);
            //        }
            //    }
            //    else
            //    {
            //        if (nameList.Exists(x => x == arrayComand[0]))
            //        {
            //            nameList.Remove(arrayComand[0]);
            //        }
            //        else
            //        {
            //            Console.WriteLine($"{arrayComand[0]} is not in the list!");
            //        }
     
            //    }

            //    counter++;
            //}
            for (int i = 0; i < numberComands; i++)
            {
                string[] arrayComand = Console.ReadLine().Split();

                if (arrayComand.Length < 4)
                {
                    if (nameList.Exists(x => x == arrayComand[0]))
                    {
                        Console.WriteLine($"{arrayComand[0]} is already in the list!");
                    }
                    else
                    {
                        nameList.Add(arrayComand[0]);
                    }
                }
                else
                {
                    if (nameList.Exists(x => x == arrayComand[0]))
                    {
                        nameList.Remove(arrayComand[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{arrayComand[0]} is not in the list!");
                    }

                }
            }

            for (int i = 0; i < nameList.Capacity; i++)
            {
                Console.Write(nameList[i]);
            }

        }
    }
}

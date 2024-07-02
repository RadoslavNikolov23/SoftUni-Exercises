namespace _03.HouseParty_2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int numberComands = int.Parse(Console.ReadLine());
            List<string> nameList = new List<string>();
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
            
            for (int i = 0; i < nameList.Count; i++)
            {
                Console.WriteLine(nameList[i]);
            }

        }
    }
}

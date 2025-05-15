namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //The first input line will hold a list of integers. Until we receive the "End" command,
            //we will be given operations we have to apply to the list.

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arrayComannd = command.Split();

                switch (arrayComannd[0])
                {
                    //    The possible commands are:
                    case "Add":
                        //    •	Add { number} – add the given number to the end of the list
                        list.Add(int.Parse(arrayComannd[1]));
                        break;
                    case "Insert":
                        //    •	Insert { number} { index} – insert the number at the given index
                        if (ChechIndex(list,arrayComannd[2]))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.Insert(int.Parse(arrayComannd[2]), int.Parse(arrayComannd[1]));
                        }
                        
                        break;
                    case "Remove":
                        //    •	Remove { index} – remove the number at the given index
                        if (ChechIndex(list, arrayComannd[1]))
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.RemoveAt(int.Parse(arrayComannd[1]));
                        }
                        break;
                    case "Shift":
                        switch (arrayComannd[1])
                        {
                            case "left":
                                // •	Shift left { count} – first number becomes last. This has to be repeated the specified number of times
                                int countLeft = int.Parse(arrayComannd[2]);
                                countLeft %=  list.Count;
                                for (int i = 0; i < countLeft; i++)
                                {
                                    int temp= list[0];
                                    list.RemoveAt(0);
                                    list.Add(temp);
                                }
                                break;

                            case "right":
                                //  •	Shift right { count} – last number becomes first. To be repeated the specified number of times
                                int countRight = int.Parse(arrayComannd[2]);
                                countRight %= list.Count;
                                for (int i = 0; i < countRight; i++)
                                {
                                    int temp = list[list.Count-1];
                                    list.RemoveAt(list.Count - 1);
                                    list.Insert(0,temp);
                                }
                                break;
                        }
                        break;


                }

            }

            Console.WriteLine(string.Join(" ",list));
            //Note: the index given may be outside of the bounds of the array. In that case print: "Invalid index".


        }

         static bool ChechIndex(List<int> list, string index)
         {
             int number = int.Parse(index);
             if (number < 0 || number >= list.Count)
             {
                 return true;
             }
             else
             {
                 return false;
             }

        }
    }
}

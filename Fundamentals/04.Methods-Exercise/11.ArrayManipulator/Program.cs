

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arrayMain = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string inputMain;

            while ((inputMain = Console.ReadLine()) != "end")
            {
                string[] inputArray = inputMain.Split(" ");

                string firstComan = inputArray[0];


                //string evenOrodd;
                switch (firstComan)
                {
                    case "exchange":
                        int indexNumber = int.Parse(inputArray[1]);
                        if (indexNumber<0 || indexNumber > arrayMain.Length-1)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            arrayMain = CheckExchangeArray(arrayMain, indexNumber);
                            // Console.WriteLine(string.Join(" ", arrayMain));
                        }

                        break;
                    case "max":
                        string maxEvenOrOdd = inputArray[1];
                        CheckMaxIndex(arrayMain, maxEvenOrOdd);
                        break;
                    case "min":
                        string minEvenOrOdd = inputArray[1];
                        CheckMinIndex(arrayMain, minEvenOrOdd);
                        break;
                    case "first":
                        string firstIndexEvenOrOdd = inputArray[2];
                        int firstCounter = int.Parse(inputArray[1]);
                        CheckFirstIndex(arrayMain, firstIndexEvenOrOdd, firstCounter);
                        break;
                    case "last":
                        string lastIndexEvenOrOdd = inputArray[2];
                        int lastCounter = int.Parse(inputArray[1]);
                        CheckLastIndex(arrayMain, lastIndexEvenOrOdd, lastCounter);
                        break;
                }
            }

            Console.WriteLine($"[{string.Join(", ", arrayMain)}]");
        }

         static void CheckLastIndex(int[] arrayMain, string lastIndexEvenOrOdd, int lastCounter)
        {
            if (/*lastCounter < 0 ||*/  lastCounter > arrayMain.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int methCoun = 0;
            string lastIndexArray="";

            for (int i = arrayMain.Length-1; i >=0 ; i--)
            {
                if (lastIndexEvenOrOdd == "even" && arrayMain[i] % 2 == 0)
                {
                    // lastIndexArray += arrayMain[i] + ", ";
                    lastIndexArray = $"{arrayMain[i]}, " + lastIndexArray;

                    methCoun++;
                    if (methCoun >= 2)
                    {
                        break;
                    }
                }

                else if (lastIndexEvenOrOdd == "odd" && arrayMain[i] % 2 != 0)
                {
                    lastIndexArray = arrayMain[i] + ", "+ lastIndexArray;
                    methCoun++;
                    if (methCoun >= lastCounter)
                    {
                        break;
                    }
                }
            }

            if (methCoun == 0)
            {
                Console.WriteLine($"[]");
            }
            else //if (methCoun >= 2)
            {
                Console.WriteLine($"[{lastIndexArray.Trim(' ', ',')}]");
            }

        }

        static void CheckFirstIndex(int[] arrayMain, string firstIndexEvenOrOdd, int firstCounter)
        {
            if (/*firstCounter < 0 ||*/ firstCounter > arrayMain.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int methCoun = 0;
            string firstIndexArray = "";

            for (int i = 0; i < arrayMain.Length; i++)
            {
                if (firstIndexEvenOrOdd == "even" && arrayMain[i] % 2 == 0)
                {
                    firstIndexArray += $"{arrayMain[i]}, ";
                     
                    methCoun++;
                    if (methCoun >= firstCounter)
                    {
                        break;
                    }
                }

                else if (firstIndexEvenOrOdd == "odd" && arrayMain[i] % 2 != 0)
                {
                    firstIndexArray += arrayMain[i] + ", ";
                    methCoun++;
                    if (methCoun >= 2)
                    {
                        break;
                    }
                }

            }

            if (methCoun == 0)
            {
                Console.WriteLine($"[]");
            }
            else //if (methCoun >= 2)
            {
                Console.WriteLine($"[{firstIndexArray.Trim(',', ' ')}]");
            }
            //•	first { count} even / odd – returns the first { count} elements-> [1, 8, 2, 3]->first 2 even->print[8, 2]
            //o If the count is greater than the array length, print "Invalid count"
            //o If there are not enough elements to satisfy the count, print as many as you can.
            //    If there are zero even / odd elements, print an empty array "[]"

        }

        static void CheckMinIndex(int[] arrayMain, string minEvenOrOdd)
        {
            int indexValue = int.MaxValue;
            int indexNumber = -1;
            int counter = 0;
            for (int i = 0; i < arrayMain.Length; i++)
            {
                if (minEvenOrOdd == "even" && arrayMain[i] % 2 == 0)
                {
                    if (indexValue >= arrayMain[i])
                    {
                        indexValue = arrayMain[i];
                        indexNumber = i;
                        counter++;
                    }
                }
                else if (minEvenOrOdd == "odd" && arrayMain[i] % 2 != 0)
                {
                    if (indexValue >= arrayMain[i])
                    {
                        indexValue = arrayMain[i];
                        indexNumber = i;
                        counter++;
                    }
                }

                // •	min even/ odd – returns the INDEX of the min even / odd element-> [1, 4, 8, 2, 3]->min even > print 3

            }

            if (indexNumber > -1)
            {
                Console.WriteLine(indexNumber);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void CheckMaxIndex(int[] arrayMain, string maxEvenOrOdd)
        {
            int indexValue = int.MinValue;
            int indexNumber = -1;
            int counter = 0;
            for (int i = 0; i < arrayMain.Length; i++)
            {
                if (maxEvenOrOdd == "even" && arrayMain[i] % 2 == 0)
                {
                    if (indexValue <= arrayMain[i])
                    {
                        indexValue = arrayMain[i];
                        indexNumber = i;
                        counter++;
                    }
                }
                else if (maxEvenOrOdd == "odd" && arrayMain[i] % 2 != 0)
                {
                    if (indexValue <= arrayMain[i])
                    {
                        indexValue = arrayMain[i];
                        indexNumber = i;
                        counter++;
                    }
                }

            }

            if (indexNumber > -1)
            {
                Console.WriteLine(indexNumber);
            }
            else
            {
                Console.WriteLine("No matches");
            }
            //  •	max even/ odd – returns the INDEX of the max even / odd element-> [1, 4, 8, 2, 3]->max odd->print 4
        }

        static int[] CheckExchangeArray(int[] arrayMain, int indexNumber)
        {
            int[] tempArray = new int[arrayMain.Length];
            int count = 0;

            for (int i = indexNumber + 1; i < arrayMain.Length; i++)
            {
                tempArray[count++] = arrayMain[i];

            }

            for (int i = 0; i <= indexNumber; i++)
            {
                tempArray[count++] = arrayMain[i];
            }

            return tempArray;
            //•	exchange { index} – splits the array after the given index
            //and exchanges the places of the two resulting sub-arrays.E.g. [1, 2, 3, 4, 5]->exchange 2->result: [4, 5, 1, 2, 3]
            //o If the index is outside the boundaries of the array, print "Invalid index"

        }
    }
}

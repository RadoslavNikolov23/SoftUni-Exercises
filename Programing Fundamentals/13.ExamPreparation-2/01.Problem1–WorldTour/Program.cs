using System.Text;

namespace _01.Problem1_WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string inputStops = Console.ReadLine();

            StringBuilder stops = new StringBuilder(inputStops);

            string comands;
            while ((comands = Console.ReadLine()) != "Travel")
            {
                string[] arrayComands = comands.Split(":");
                string firstComand = arrayComands[0];

                switch (firstComand)
                {
                    case "Add Stop":
                        int indexAdd = int.Parse(arrayComands[1]);
                        string addString = arrayComands[2];
                        if (IndexIsValid(indexAdd, stops.Length))
                        {
                            stops.Insert(indexAdd, addString);
                        }
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(stops);
                        //  Console.ForegroundColor = ConsoleColor.White;

                        break;

                    case "Remove Stop":
                        //•	"Remove Stop:{start_index}:{end_index}":
                        int startIndexRemove = int.Parse(arrayComands[1]);
                        int endIndexRemove = int.Parse(arrayComands[2]);

                        if (IndexIsValid(startIndexRemove, stops.Length)
                            && IndexIsValid(endIndexRemove, stops.Length)
                            && endIndexRemove >= startIndexRemove)
                        {
                            stops.Remove(startIndexRemove, endIndexRemove - startIndexRemove + 1);
                        }
                        // Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(stops);
                        // Console.ForegroundColor = ConsoleColor.White;

                        break;

                    case "Switch":
                        string oldString = arrayComands[1];
                        string newString = arrayComands[2];

                        if (stops.ToString().Contains(oldString))
                        {
                            stops.Replace(oldString, newString);
                        }
                        // Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(stops);
                        //  Console.ForegroundColor = ConsoleColor.White;

                        break;
                }
            }
            // Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
            //Console.ForegroundColor = ConsoleColor.White;

        }

        public static bool IndexIsValid(int indexAdd, int stopsLength)
        {
            if (indexAdd < 0 || indexAdd >= stopsLength)
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

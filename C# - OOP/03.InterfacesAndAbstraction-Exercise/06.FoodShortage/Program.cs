using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string,IBuyer> peopleByName= new Dictionary<string,IBuyer>();

            int numberPeople = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberPeople; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    peopleByName.Add(data[0], new Rebel(data[0], int.Parse(data[1]), data[2]));
                }
                else if(data.Length == 4)
                {
                    peopleByName.Add(data[0], new Citizen(data[0], int.Parse(data[1]), data[2], data[3]));
                }
            }

            string input=Console.ReadLine();
            while (input != "End")
            {

                //not all names may be valid, in case of an incorrect name - nothing should happen.
                if (peopleByName.ContainsKey(input))
                {
                    peopleByName[input].BuyFood();
                }

               

                input = Console.ReadLine();
            }

                Console.WriteLine(peopleByName.Values.Sum(x=>x.Food));
         


        }


    }
}

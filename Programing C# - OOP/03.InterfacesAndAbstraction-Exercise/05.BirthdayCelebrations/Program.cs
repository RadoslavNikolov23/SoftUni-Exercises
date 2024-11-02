using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            List<IBirthday> birthdays = new List<IBirthday>();
            List<IIdentification> identities = new List<IIdentification>();

            while (input != "End")
            {
                string[] data = input.Split();

                if (data[0] == "Citizen")
                {
                   birthdays.Add(new Citizen(data[1], int.Parse(data[2]), data[3], data[4]));
                    identities.Add(new Citizen(data[1], int.Parse(data[2]), data[3], data[4]));
                }
                else if (data[0] == "Robot")
                {
                    identities.Add(new Robot(data[1],data[2]));
                }
                else if (data[0] == "Pet")
                {
                    birthdays.Add(new Pet(data[1],data[2]));
                }

                input = Console.ReadLine();
            }

            string birthdayYear = Console.ReadLine();

            foreach(var  birthday in birthdays.Where(x => x.Birthday.EndsWith(birthdayYear)))
            {
                Console.WriteLine(birthday.Birthday);
            }


        }


    }
}

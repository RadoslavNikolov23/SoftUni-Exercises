using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();

            List<IIdentification> identification = new List<IIdentification>();


            while (input != "End")
            {
                string[] array = input.Split();

                AddCitizenRobots(identification, array);

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            

            foreach (var id in identification.Where(id => id.Id.EndsWith(fakeId))) 
                Console.WriteLine(id.Id);
           

          
        }

      
        private static void AddCitizenRobots(List<IIdentification> identification, string[] array)
        {
            if (array.Length == 2)
            {
                Robot robot = new Robot(array[0], array[1]);
                identification.Add(robot);
            }
            else if (array.Length == 3)
            {
                Citizen citizen = new Citizen(array[0], int.Parse(array[1]), array[2]);
                identification.Add(citizen);

            }
        }
    }
}

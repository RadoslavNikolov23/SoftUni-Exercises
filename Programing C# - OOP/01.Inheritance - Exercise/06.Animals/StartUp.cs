using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;


namespace Animals
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            string data = Console.ReadLine();

            while (data != "Beast!")
            {
                try
                {
                    string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = array[0];
                    int age = int.Parse(array[1]);
                    string gender = array[2];
                    Animal animal = null;
                    switch (data)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;


                        case "Cat":
                            animal = new Cat(name, age, gender);

                            break;
                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;

                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;


                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;


                    }
                    Console.WriteLine(animal);

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

                data = Console.ReadLine();
            }

        }
    }
}

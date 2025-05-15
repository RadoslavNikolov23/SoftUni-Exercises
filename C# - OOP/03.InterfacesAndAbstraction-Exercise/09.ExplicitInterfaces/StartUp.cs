﻿namespace _09.ExplicitInterfaces
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = input.Split();
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);
                Citizen citizen = new Citizen(name, country, age);
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}

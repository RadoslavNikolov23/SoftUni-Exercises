﻿namespace _06.ForeignLanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string languege=Console.ReadLine();

            switch (languege)
            {
                case "USA":
                case "England":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                   
                default:Console.WriteLine("unknown");
                    break;

            }
        }
    }
}

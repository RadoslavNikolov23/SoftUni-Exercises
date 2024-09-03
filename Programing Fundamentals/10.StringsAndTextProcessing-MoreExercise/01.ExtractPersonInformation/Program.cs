using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberLines = int.Parse(Console.ReadLine());
            Dictionary<string,string> nameAndAgeDT= new Dictionary<string,string>();

            for (int i = 0; i < numberLines; i++)
            {
                string input = Console.ReadLine();
                //string[] temp = input.Split(new[] { '@', '|', '#', '*'});
                int index1=0;
                int index2=0;
                int index3=0;
                int index4=0;

                for (int k = 0; k < input.Length; k++)
                {
                    char temp = input[k];
                    if (temp == '@')
                    {
                        index1 = k;
                    }
                    if (temp == '|')
                    {
                        index2 = k;
                    }
                    if (temp == '#')
                    {
                        index3 = k;
                    }
                    if (temp == '*')
                    {
                        index4 = k;
                    }

                }

                string name=string.Empty;
                string age=string.Empty;
                name = input.Substring(index1+1,index2-index1-1);
                age = input.Substring(index3+1, index4-index3-1);

                nameAndAgeDT.Add(name, age);
            }

            foreach (var nameAge in nameAndAgeDT)
            {
                Console.WriteLine($"{nameAge.Key} is {nameAge.Value} years old.");

            }
        }
    }
}

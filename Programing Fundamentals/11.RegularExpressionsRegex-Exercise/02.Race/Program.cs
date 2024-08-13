using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Participant
    {
        public string Name;
        public int Distance;

        public Participant(string name, int distance)
        {
            Name = name;
            Distance = distance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participantNames = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, Participant> participantDict = new Dictionary<string, Participant>();

            foreach (var name in participantNames)
            {
                participantDict.Add(name, new Participant(name, -1));
            }

            string paternName = @"[A-Za-z]";
            string paternDistance = @"[0-9]";
            string input;

            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = string.Empty;
                int distance = 0;

                foreach (Match letters in Regex.Matches(input, paternName))
                {
                    name += letters.Value;

                }

                foreach (Match numbers in Regex.Matches(input, paternDistance))
                {
                    distance += int.Parse(numbers.Value);
                }

                if (participantDict.Keys.Contains(name))
                {
                    participantDict[name].Distance += distance;
                }
            }

            var orderFinalList = participantDict.OrderByDescending(x => x.Value.Distance).ToList();
          

            Console.WriteLine($"1st place: {orderFinalList[0].Value.Name}");
            Console.WriteLine($"2nd place: {orderFinalList[1].Value.Name}");
            Console.WriteLine($"3rd place: {orderFinalList[2].Value.Name}");



        }
    }
}

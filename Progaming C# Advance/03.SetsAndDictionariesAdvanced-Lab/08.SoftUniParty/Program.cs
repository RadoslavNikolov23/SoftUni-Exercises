using System;
using System.Collections.Generic;

namespace _08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> vipSet = new HashSet<string>();
            HashSet<string> regularGuestSet = new HashSet<string>();

            HashSet<string> vipArrivedSet = new HashSet<string>();
            HashSet<string> guestArrivedSet = new HashSet<string>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input.Length == 8)
                {
                    char firstLetter = input[0];

                    if (char.IsDigit(firstLetter))
                    {
                        vipSet.Add(input);
                    }
                    else
                    {
                        regularGuestSet.Add(input);
                    }
                }

                else if (input == "PARTY")
                {
                    break;
                }
                input = Console.ReadLine();
            }

            while (true)
            {

                if (vipSet.Contains(input))
                {
                    vipArrivedSet.Add(input);
                }
                else if (regularGuestSet.Contains(input))
                {
                    guestArrivedSet.Add(input);
                }

                if (input == "END")
                {
                    break;
                }
                input = Console.ReadLine();
            }

            int sumArrivedGuest = vipArrivedSet.Count + guestArrivedSet.Count;
            int sumReservations = vipSet.Count + regularGuestSet.Count;
            int sumGuestWhoDidntCame = 0;

            if (sumReservations > sumArrivedGuest)
                sumGuestWhoDidntCame = sumReservations - sumArrivedGuest;


            List<string> guestThatDidntCameList = new List<string>();

            foreach(var guest in vipSet)
            {
                if (vipArrivedSet.Contains(guest))
                {
                    continue;
                }
                else
                {
                    guestThatDidntCameList.Add(guest);
                }
            }
            
            foreach(var guest in regularGuestSet)
            {
                if (guestArrivedSet.Contains(guest))
                {
                    continue;
                }
                else
                {
                    guestThatDidntCameList.Add(guest);
                }
            }



            Console.WriteLine(sumGuestWhoDidntCame);
            Console.WriteLine(string.Join("\n", guestThatDidntCameList));
           
        }
    }
}

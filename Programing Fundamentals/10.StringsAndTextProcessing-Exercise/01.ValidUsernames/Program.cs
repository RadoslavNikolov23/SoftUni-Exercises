using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            List<string> validUsernames = new List<string>();

            //  usernames.Any(username => username.Length >= 3 && username.Length <= 16
            //                                        && username.Any(symb=>char.IsLetterOrDigit(symb) ||
            //                                        symb=='-'||
            //                                        symb== '_'));

            foreach (var username in usernames)
            {
                if( username.Length >= 3 && 
                    username.Length <= 16 && 
                    username.All(symb => char.IsLetterOrDigit(symb) ||
                                                    symb == '-' ||
                                                    symb == '_'))
                {
                    validUsernames.Add(username);
                }
            }

            // Console.WriteLine(string.Join(" ", validUsernames));
            validUsernames.ForEach(username => Console.WriteLine(username));

        }
    }
}

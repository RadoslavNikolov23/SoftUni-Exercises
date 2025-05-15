using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        class Participants
        {
            public Participants(string name, int healt, decimal damage)
            {
                Name = name;
                Healt = healt;
                Damage = damage;
            }

            public string Name;
            public int Healt;
            public decimal Damage;

        }
        static void Main(string[] args)
        {
            
            string[] arrayParticipants = Console.ReadLine().Split(',', ' ', StringSplitOptions.TrimEntries);
            string patternLettersForHealt = @"[^0-9\+\-\*\/\.\s]";
            string patternDigitsForDamage = @"(?:(?:[-+]*)(?:\d+\.\d+|\d+))";
            string patternForDivideOrMultiply = @"[\*]|[\/]";

           

            List<Participants> participants = new List<Participants>();

            foreach (var member in arrayParticipants)
            {
                int healt = 0;
                decimal damage = 0;
                foreach (Match match in Regex.Matches(member, patternLettersForHealt))
                {
                    
                        healt += match.Value[0];
                    
                }

                foreach (Match match in Regex.Matches(member, patternDigitsForDamage))
                {
                    string temp = match.Value;
                    damage += decimal.Parse(temp);
                }


                
                foreach (Match match in Regex.Matches(member, patternForDivideOrMultiply))
                {
                    switch (match.Value)
                    {
                        case "/":
                            damage /= 2;
                            break;
                        case "*":
                            damage *= 2;
                            break;
                    }
                }


                participants.Add(new Participants(member,healt,damage));
            }

            participants = participants.OrderBy(m => m.Name).ToList();
            foreach (var member in participants)
            {
                Console.WriteLine($"{member.Name} - {member.Healt} health, {member.Damage:f2} damage");
            }




        }
    }
}

using System.Text.RegularExpressions;
using System.Linq;


namespace _04.StarEnigma
{
    internal class Program
    {
        class Message
        {
            public string PlaneName;
            public int Population;
            public string AttackType;
            public int SoldierCount;

            public Message(string planeName, int population, string attackType, int soldierCount)
            {
                PlaneName = planeName;
                Population = population;
                AttackType = attackType;
                SoldierCount = soldierCount;
            }

        }
        static void Main(string[] args)
        {
            int numberInputs = int.Parse(Console.ReadLine());

            string patternFisrt = @"[STARstar]";
            string patternDecripted = @"\@(?<Planet>[A-Z][a-z]+)([^\@\-\!\:\>])*\:([^\@\-\!\:\>])*(?<Population>\d+)([^\@\-\!\:\>])*\!([^\@\-\!\:\>])?(?<Type>A|D)([^\@\-\!\:\>])*\!([^\@\-\!\:\>])*([^\@\-\!\:\>])*\-\>([^\@\-\!\:\>])*(?<Soldiers>\d+)([^\@\-\!\:\>])*"; List<Message> messages = new List<Message>();

            for (int i = 0; i < numberInputs; i++)
            {
                string input = Console.ReadLine();

                // int count = Regex.Count(input, patternFisrt);
                int count = 0;
                foreach (Match match in Regex.Matches(input, patternFisrt))
                {
                    if (match.Success)
                    {
                        count++;
                    }
                }

                string newInput = String.Empty;
                for (int j = 0; j < input.Length; j++)
                {
                    newInput += (char)(input[j] - count);
                }

                foreach (Match match in Regex.Matches(newInput, patternDecripted))
                {
                    messages.Add(new Message
                    (match.Groups["Planet"].Value,
                        int.Parse(match.Groups["Population"].Value),
                        match.Groups["Type"].Value,
                        int.Parse(match.Groups["Soldiers"].Value)));
                }

            }
            int countAttacked = 0;

            //   int countAttackedPlanets = messages.Count(x => x.AttackType == "A");
           messages.ForEach(plan =>
           {
               if (plan.AttackType.Contains("A"))
               {
                   countAttacked++;
               }
           });

            //int countDestrictionPlanets = messages.Count(x => x.AttackType == "D");

            int countDestriction = 0;
            messages = messages.OrderBy(x => x.PlaneName).ToList();


            messages.ForEach(plan =>
            {
                if (plan.AttackType.Contains("D"))
                {
                    countDestriction++;
                }
            });
            Console.WriteLine($"Attacked planets: {countAttacked}");
            foreach (var planet in messages)
            {
                if (planet.AttackType == "A")
                {
                    Console.WriteLine($"-> {planet.PlaneName}");
                }
            }
            Console.WriteLine($"Destroyed planets: {countDestriction}");
            foreach (var planet in messages)
            {
                if (planet.AttackType == "D")
                {
                    Console.WriteLine($"-> {planet.PlaneName}");
                }
            }



        }
    }
}

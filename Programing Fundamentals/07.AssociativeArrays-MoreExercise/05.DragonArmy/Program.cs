

namespace _05.DragonArmy
{
    internal class Program
    {
        class DragonStats
        {
            public DragonStats(decimal statDamage, decimal statHealt, decimal statArmor)
            {
                StatDamage = statDamage;
                StatHealt = statHealt;
                StatArmor = statArmor;
            }

            public decimal StatDamage { get; set; }
            public decimal StatHealt { get; set; }
            public decimal StatArmor { get; set; }
        }
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, DragonStats>> dragonDictionary =
                new Dictionary<string, Dictionary<string, DragonStats>>();

            int numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                string type = input[0];
                string name = input[1];
                decimal damage;
                decimal healt;
                decimal armor;

                if (!decimal.TryParse(input[2], out damage))
                {
                    damage = 45;
                }
                if (!decimal.TryParse(input[3], out healt))
                {
                    healt = 250;
                }
                if (!decimal.TryParse(input[4], out armor))
                {
                    armor = 10;
                }

                if (!dragonDictionary.ContainsKey(type))
                {
                    dragonDictionary.Add(type, new Dictionary<string, DragonStats>());

                }

                if (!dragonDictionary[type].ContainsKey(name))
                {
                    dragonDictionary[type].Add(name,new DragonStats(0,0,0));
                }

                    dragonDictionary[type][name].StatArmor=armor;
                    dragonDictionary[type][name].StatDamage=damage;
                    dragonDictionary[type][name].StatHealt=healt;



            }

            dragonDictionary.OrderBy(dr => dr.Key);

            foreach (var dragon in dragonDictionary)
            {
                decimal avaregDamage=dragon.Value.Average(x=>x.Value.StatDamage);
                decimal avaregHealt =dragon.Value.Average(x => x.Value.StatHealt);
                decimal avaregArmor = dragon.Value.Average(x => x.Value.StatArmor);
               

                Console.WriteLine($"{dragon.Key}::({avaregDamage:F2}/{avaregHealt:f2}/{avaregArmor:f2})");

                foreach (var drg in dragon.Value.OrderBy(x => x.Key))
                {

                    Console.WriteLine($"-{drg.Key} -> damage: {drg.Value.StatDamage}, health: {drg.Value.StatHealt}, armor: {drg.Value.StatArmor}");

                }

            }

        }
    }
}

using Raiding.Heroes;

namespace Raiding;

public class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<BaseHero> heroes = new List<BaseHero>();

        for(int i = 0; i < number; i++)
        {
            string heroName=Console.ReadLine();
            string heroType=Console.ReadLine();

            if (!InitializeHero(heroes, heroName, heroType)) i--;
        }

        int bossPower = int.Parse(Console.ReadLine());

        heroes.ForEach(x => Console.WriteLine(x.CastAbility()));


        int sumAll = heroes.Sum(x=>x.Power);

        if (sumAll >= bossPower) Console.WriteLine("Victory!");
        else Console.WriteLine("Defeat...");

    }

    private static bool InitializeHero(List<BaseHero> heroes, string? heroName, string? heroType)
    {
        switch (heroType)
        {
            case "Druid":
                heroes.Add(new Druid(heroName));
                return true;
                break;
            case "Paladin":
                heroes.Add(new Paladin(heroName));
                return true;
                break;
            case "Rogue":
                heroes.Add(new Rogue(heroName));
                return true;
                break;
            case "Warrior":
                heroes.Add(new Warrior(heroName));
                return true;
                break;
            default: Console.WriteLine("Invalid hero!");
                return false;
                break;
        }
    }
}

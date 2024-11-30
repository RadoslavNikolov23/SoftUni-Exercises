using MilitaryElite.Soldiers;
using MilitaryElite.Soldiers.Interfaces;
using MilitaryElite.Soldiers.SpecialisedSoliders;

namespace MilitaryElite;

public class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<ISoldier> soldiersList = new List<ISoldier>();
        List<IPrivate> priveteList = new List<IPrivate>();
        while (input != "End")
        {
            string[] typeSoledier = input.Split(" ");

            ISoldier soldier = null;
            string id = typeSoledier[1];
            string firstName = typeSoledier[2];
            string lastName = typeSoledier[3];

            try
            {
                if (typeSoledier[0] == nameof(Private))
                {
                    soldier = GeneratePrivate(id, firstName, lastName, typeSoledier);
                    priveteList.Add((IPrivate)soldier!);
                }
                else if (typeSoledier[0] == nameof(LieutenantGeneral))
                {
                    soldier = GenerateLeiutenathGeneral(id, firstName, lastName, typeSoledier, priveteList);
                }
                else if (typeSoledier[0] == nameof(Engineer))
                {
                    if (ValidetedCorps(typeSoledier))
                    {
                        soldier = GenerateEngineer(id, firstName, lastName, typeSoledier);
                    }

                }
                else if (typeSoledier[0] == nameof(Commando))
                {
                    if (ValidetedCorps(typeSoledier))
                    {
                        soldier = GenerateComando(id, firstName, lastName, typeSoledier);
                    }
                }
                else if (typeSoledier[0] == nameof(Spy))
                {
                    soldier = GenerateSpy(id, firstName, lastName, typeSoledier);
                }
                soldiersList.Add(soldier);
            }
            catch (Exception)
            {
            }
            
            input = Console.ReadLine();
        }

        foreach (ISoldier soldiers in soldiersList)
        {
            Console.WriteLine(soldiers);
        }
    }

    private static ISoldier GenerateSpy(string id, string firstName, string lastName, string[] typeSoledier)
    {
        int codeNumber = int.Parse(typeSoledier[4]);
        return new Spy(id, firstName, lastName, codeNumber);
    }

    private static ISoldier? GenerateComando(string id, string firstName, string lastName, string[] typeSoledier)
    {

        decimal salary = decimal.Parse(typeSoledier[4]);
        Corps corps = new Corps();
        if (typeSoledier[5] == Corps.Marines.ToString())
        {
            corps = Corps.Marines;
        }
        else if (typeSoledier[5] == Corps.Airforces.ToString())
        {
            corps = Corps.Airforces;
        }

        Dictionary<string, State> codeNameByState = new Dictionary<string, State>();

        for (int i = 6; i < typeSoledier.Length; i += 2)
        {
            if (typeSoledier[i + 1] == State.Finished.ToString())
            {
                codeNameByState[typeSoledier[i]] = State.Finished;
            }
            else if (typeSoledier[i + 1] == State.InProgress.ToString())
            {
                codeNameByState[typeSoledier[i]] = State.InProgress;
            }

        }
        return new Commando(id, firstName, lastName, salary, corps, codeNameByState);
    }

    private static ISoldier GenerateEngineer(string id, string firstName, string lastName, string[] typeSoledier)
    {
        decimal salary = decimal.Parse(typeSoledier[4]);
        Corps corps = new Corps();
        if (typeSoledier[5] == Corps.Marines.ToString())
        {
            corps = Corps.Marines;
        }
        else if (typeSoledier[5] == Corps.Airforces.ToString())
        {
            corps = Corps.Airforces;
        }

        Dictionary<string, int> reapirsByHours = new Dictionary<string, int>();

        for (int i = 6; i < typeSoledier.Length; i += 2)
        {
            reapirsByHours[typeSoledier[i]] = int.Parse(typeSoledier[i + 1]);
        }

        return new Engineer(id, firstName, lastName, salary, corps, reapirsByHours);
    }

    private static ISoldier? GenerateLeiutenathGeneral(string id, string firstName, string lastName, string[] typeSoledier, List<IPrivate> priveteList)
    {
        decimal salary = decimal.Parse(typeSoledier[4]);
        List<IPrivate> privates = new List<IPrivate>();
        for (int i = 5; i < typeSoledier.Length; i++)
        {
            string idToMatch = typeSoledier[i];
            if (priveteList.Any(p => p.Id == idToMatch))
            {
                privates.Add(priveteList.First(s => s.Id == idToMatch));
            }
        }
        return new LieutenantGeneral(id, firstName, lastName, salary, privates);
    }

    private static ISoldier? GeneratePrivate(string id, string firstName, string lastName, string[] typeSoledier)
    {
        decimal salary = decimal.Parse(typeSoledier[4]);
        return new Private(id, firstName, lastName, salary);
    }

    private static bool ValidetedCorps(string[] typeSoledier)
    {
        if (typeSoledier[5] == Corps.Marines.ToString() || typeSoledier[5] == Corps.Airforces.ToString())
        {
            return true;
        }
        return false;
    }
}




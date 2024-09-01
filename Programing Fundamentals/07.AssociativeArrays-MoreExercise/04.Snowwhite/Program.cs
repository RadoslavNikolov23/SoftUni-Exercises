namespace _04.Snowwhite
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Dictionary<string, int> dwarfDictionary = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] arrayInput = input.Split("<:>", StringSplitOptions.TrimEntries);
                string dwarfName = arrayInput[0];
                string dwarfHatColor = arrayInput[1];
                int dwarfPhysics = int.Parse(arrayInput[2]);

                string nameAndHat = $"({dwarfHatColor}) {dwarfName}";

                if (!dwarfDictionary.ContainsKey(nameAndHat))
                {
                    dwarfDictionary.Add(nameAndHat, dwarfPhysics);
                }

                if(dwarfDictionary.ContainsKey(nameAndHat))
                {
                    if (dwarfDictionary.Values.Any(x => x < dwarfPhysics))
                    {
                        dwarfDictionary[nameAndHat]= dwarfPhysics;
                    }
                }



            }


            foreach (var dwarf in dwarfDictionary.OrderByDescending(dw=>dw.Value)
                         .ThenByDescending(dw => dwarfDictionary.Where(d => d.Key.Split(")")[0] == dw.Key.Split(")")[0])
                             .Count()))
            {
                Console.WriteLine($"{dwarf.Key} <-> {dwarf.Value}");

            }

        }
    }
}


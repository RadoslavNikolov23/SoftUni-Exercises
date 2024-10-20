using System.Text;

namespace CreaturesOfTheCode
{
    public class MythicalCreaturesHub
    {
        public MythicalCreaturesHub(int capacity)
        {
            this.Creatures = new List<Creature>();
            this.Capacity = capacity;
        }
        public int Capacity { get; set; }
        private List<Creature> Creatures { get; set; }


        public void AddCreature(Creature creature)
        {
            if (this.Capacity > this.Creatures.Count)
            {
                if (!this.Creatures.Any(x => x.Name.ToLower() == creature.Name.ToLower())) this.Creatures.Add(creature);
            }
        }

        public bool RemoveCreature(string name)
        {
            Creature creatureToRemove = Creatures.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (creatureToRemove != null)
            {
                Creatures.Remove(creatureToRemove);
                return true;
            }
            return false;

        }

        public Creature GetStrongestCreature()  //TODO or string?
        {
             return this.Creatures.OrderByDescending(x => x.Health).First();
        }


        public string Details(string creatureName)
        {
            Creature creature = this.Creatures.FirstOrDefault(x=>x.Name == creatureName);
      
            if (creature != null) return creature.ToString();
            else return $"Creature with the name {creatureName} not found.";
        }

        public string GetAllCreatures()
        {
            StringBuilder output= new StringBuilder();

            output.AppendLine($"Mythical Creatures:");
            foreach (Creature creature in this.Creatures.OrderBy(x => x.Name))
            {
                output.AppendLine($"{creature.Name} -> {creature.Kind}");
            }

            return output.ToString().Trim();
        }
     
    }
}

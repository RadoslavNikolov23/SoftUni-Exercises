using System.Text;

namespace CreaturesOfTheCode
{
    public class Creature
    {
        public Creature(string name, string kind, int health, string abilities)
        {
            this.Name = name;
            this.Kind = kind;
            this.Health = health;
            this.Abilities = abilities.Split(", ").ToList();
        }

        public string Name { get; set; }
        public string Kind { get; set; }
        public int Health { get; set; }
        public List<string> Abilities { get; set; }


        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{this.Name} ({this.Kind}) has {this.Health} HP");
            sbResult.AppendLine($"Abilities: {string.Join(", ", this.Abilities)}");
            return sbResult.ToString().Trim();
        }


    }
}

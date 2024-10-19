using System.Text;

namespace SharkTaxonomy
{
    public class Shark
    {
        public Shark(string kind, int length, string food, string habitat)
        {
            Kind = kind;
            Length = length;
            Food = food;
            Habitat = habitat;
        }

        public string Kind { get; set; }
        public int Length { get; set; }
        public string Food { get; set; }
        public string Habitat { get; set; }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{this.Kind} shark: {this.Length}m long.");
            sbResult.AppendLine($"Could be spotted in the {this.Habitat}, typical menu: {this.Food}");

            return sbResult.ToString().Trim();
        }

    }
}

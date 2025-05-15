using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            this.Capacity = capacity;
            this.Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount
        {
            get { return Species.Count; }
       
        }


        public void AddShark(Shark shark)
        {
            if (this.Capacity <= GetCount) return;

            if(!this.Species.Any(x=>x.Kind==shark.Kind)) Species.Add(shark);
        }


        public bool RemoveShark(string kind)
        {
            Shark shark=this.Species.FirstOrDefault(x=>x.Kind==kind);

            return Species.Remove(shark);
        }

        public string GetLargestShark() => this.Species.OrderByDescending(x => x.Length).First().ToString().Trim();

        public double GetAverageLength() => this.Species.Average(x=>x.Length);


        public string Report()
        {
            StringBuilder sharkSB= new StringBuilder();
            sharkSB.AppendLine($"{this.GetCount} sharks classified:");
            sharkSB.AppendLine($"{string.Join("\n",this.Species)}");
            sharkSB.AppendLine($"");

            return sharkSB.ToString().Trim();
        }
 
    }
}

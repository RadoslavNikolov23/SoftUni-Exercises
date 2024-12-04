using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private int oxygenLevel;
        private double competitionPoints;
        private List<string> @catch;
        public Diver(string name, int oxygenLevel)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.DiversNameNull);

            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.@catch = new List<string>();
            this.CompetitionPoints = 0;
            HasHealthIssues = false;
        }

        public string Name { get; }
        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value < 0)
                    oxygenLevel = 0;

                oxygenLevel = value;
             }
        }
        public IReadOnlyCollection<string> Catch { get => this.@catch.AsReadOnly(); }
        public double CompetitionPoints { get => Math.Round(competitionPoints, 1); private set => competitionPoints = value; }
        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            this.oxygenLevel-=fish.TimeToCatch;
            @catch.Add(fish.Name);
            this.competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);


        public abstract void RenewOxy();
        

        public void UpdateHealthStatus()
        {
            this.HasHealthIssues = !this.HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count()}, Points earned: {this.CompetitionPoints} ]";
        }
    }
}

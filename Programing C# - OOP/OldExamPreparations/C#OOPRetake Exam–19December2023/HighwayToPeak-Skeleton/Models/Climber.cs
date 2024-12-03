using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private List<string> conqueredPeaks;
        private int stamina;
        protected Climber(string name, int stamina)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);


            this.Name = name;

            this.Stamina = stamina;
            conqueredPeaks = new List<string>();
        }

        public string Name { get; }
        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value < 0)
                    stamina = 0;
                else if (value > 10)
                    stamina = 10;
                else
                    stamina = value;
            }
        }
        public IReadOnlyCollection<string> ConqueredPeaks { get => this.conqueredPeaks.AsReadOnly(); }

        public void Climb(IPeak peak)
        {
            string peakName=peak.Name;
            if (!this.conqueredPeaks.Any(c=>c==peakName))
            {
                this.conqueredPeaks.Add(peakName);
            }
           string peakDifficultyLevel=peak.DifficultyLevel;

            if (peakDifficultyLevel == "Extreme")
                this.Stamina -= 6; 
            else if (peakDifficultyLevel == "Hard")
                this.Stamina -= 4; 
            else if (peakDifficultyLevel == "Moderate")
                this.Stamina -= 2;

        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            return $"{this.GetType().Name} - Name: {this.Name}, Stamina: {this.Stamina} {Environment.NewLine}Peaks conquered: no peaks conquered /{this.conqueredPeaks.Count()}";

        }

    }
}

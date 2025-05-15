using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private BaseCamp basecamp;
        private ClimberRepository climberRepository;
        private PeakRepository peakRepository;

        public Controller()
        {
            basecamp = new BaseCamp();
            climberRepository = new ClimberRepository();
            peakRepository = new PeakRepository();
        }


        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak peakToFind = this.peakRepository.Get(name);
            if (peakToFind != null)
                return string.Format(OutputMessages.PeakAlreadyAdded, name);

            bool isDifficultyLevelValued = ValidetDifficultuLevel(difficultyLevel);
            if (!isDifficultyLevelValued)
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);

            IPeak peakToAdd = new Peak(name, elevation, difficultyLevel);
            this.peakRepository.Add(peakToAdd);
            return string.Format(OutputMessages.PeakIsAllowed, name, this.peakRepository.GetType().Name);

        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber climberToFind = this.climberRepository.Get(name);
            if (climberToFind != null)
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, this.climberRepository.GetType().Name);

            IClimber climerToAdd = null;
            if (isOxygenUsed)
            {
                climerToAdd = new OxygenClimber(name);
            }
            else
            {
                climerToAdd = new NaturalClimber(name);
            }

            this.climberRepository.Add(climerToAdd);
            this.basecamp.ArriveAtCamp(climerToAdd.Name);
            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);


        }


        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climberToFind = this.climberRepository.Get(climberName);
            if (climberToFind == null)
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);

            IPeak peakToFind = this.peakRepository.Get(peakName);
            if (peakToFind == null)
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);

            if (!basecamp.Residents.Any(r => r == climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            string getDifficultyLevel = peakToFind.DifficultyLevel;
            string typeClimber = climberToFind.GetType().Name;
            if (getDifficultyLevel == "Extreme" && typeClimber == nameof(NaturalClimber))
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            this.basecamp.LeaveCamp(climberToFind.Name);
            climberToFind.Climb(peakToFind);

            if (climberToFind.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);

            }
            this.basecamp.ArriveAtCamp(climberToFind.Name);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);

        }


        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!basecamp.Residents.Any(r => r == climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climberToRest = this.climberRepository.Get(climberName);

            if (climberToRest.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climberToRest.Rest(daysToRecover);
            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);

        }


        public string BaseCampReport()
        {
            StringBuilder sb = new StringBuilder();
            if (this.basecamp.Residents.Count == 0)
            {
                sb.AppendLine($"BaseCamp is currently empty.");
            }
            else
            {
                sb.AppendLine($"BaseCamp residents:");
                foreach (string climber in this.basecamp.Residents)
                {
                    IClimber climberToPrint = this.climberRepository.Get(climber);
                    if (climberToPrint != null)
                    {
                        sb.AppendLine($"Name: {climberToPrint.Name}, Stamina: {climberToPrint.Stamina}, Count of Conquered Peaks: {climberToPrint.ConqueredPeaks.Count}");
                    }
                }
            }

            return sb.ToString().Trim();

        }



        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***Highway-To-Peak***");
           
            foreach(IClimber climber in this.climberRepository.All.OrderByDescending(c=>c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name))
            {
                sb.AppendLine(climber.ToString());
                Dictionary<string,IPeak> peaksByNameConquered = new Dictionary<string,IPeak>();

                foreach(string peak in climber.ConqueredPeaks)
                {
                    peaksByNameConquered[peak] = this.peakRepository.Get(peak);
                }

                foreach(var peakConquered in peaksByNameConquered.Values.OrderByDescending(v => v.Elevation))
                {
                    sb.AppendLine(peakConquered.ToString());

                }
            }

            return sb.ToString().Trim();


        }



        private bool ValidetDifficultuLevel(string difficultyLevel)
        {
            if (difficultyLevel == "Extreme" || difficultyLevel == "Hard" || difficultyLevel == "Moderate")
            {
                return true;
            }
            return false;
        }
    }
}

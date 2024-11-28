using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        private const double professionalRankingCoefficient = 1.5;
        private const double professionalStartingRanking = 60;
        public ProfessionalManager(string name) : base(name, professionalStartingRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            UpdateRanking(updateValue * professionalRankingCoefficient);

        }
    }
}

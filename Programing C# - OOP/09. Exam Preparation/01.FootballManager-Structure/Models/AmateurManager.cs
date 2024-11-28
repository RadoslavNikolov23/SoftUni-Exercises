using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {
        private const double amateurRankingCoefficient = 0.75;
        private const double amateurStartingRanking = 15;
        public AmateurManager(string name) : base(name, amateurStartingRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            UpdateRanking(updateValue * amateurRankingCoefficient);
        }
    }
}

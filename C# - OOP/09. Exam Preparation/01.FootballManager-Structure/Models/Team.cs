using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        private string name;
        private int championshipPoints;
        private int presentCondition;
        private IManager teamManager;

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.TeamNameNull);
                this.name = value;
            }
        }
        public int ChampionshipPoints
        {
            get => this.championshipPoints;
            private set => this.championshipPoints = 0;
        }
        public IManager TeamManager { get; private set; }
        public int PresentCondition
        {
            get => this.presentCondition;
            private set
            {
                if (this.TeamManager == null) this.presentCondition = 0;
                else if (this.ChampionshipPoints == 0) this.presentCondition = (int)this.TeamManager.Ranking;
                else this.presentCondition = (int)(this.ChampionshipPoints * this.TeamManager.Ranking);
            }
        }

        public void SignWith(IManager manager)
        {
           this.TeamManager = manager;

        }
        public void GainPoints(int points)
        {
            this.ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            this.ChampionshipPoints = 0;
        }

        public override string ToString()
        {
            return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        }


    }
}

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
        private IManager teamManager;

        public Team(string name)
        {
            this.Name = name;
            this.ChampionshipPoints = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                this.name = value;
            }
        }
        public int ChampionshipPoints
        {
            get => this.championshipPoints;
            private set => this.championshipPoints = value;
        }
        public IManager TeamManager { get => teamManager; private set => teamManager = value; }
        public int PresentCondition
        {
            get 
            {
                if (this.TeamManager == null) return 0;
                else if (this.ChampionshipPoints == 0) return (int)this.TeamManager.Ranking;
                else return (int)(this.ChampionshipPoints * this.TeamManager.Ranking);
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

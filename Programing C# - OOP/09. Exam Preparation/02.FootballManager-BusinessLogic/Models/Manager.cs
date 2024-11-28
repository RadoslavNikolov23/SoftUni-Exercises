using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private string name;
        private double ranking;

        protected Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);

                this.name = value;
            }
        }
        public double Ranking { get => ranking; protected set => ranking = value; }

        public abstract void RankingUpdate(double updateValue);

        protected void UpdateRanking(double rankingForMethod)
        {

            if (Ranking + rankingForMethod < 0)
            {
                Ranking = 0;
                return;
            }
            if (Ranking + rankingForMethod > 100) 
            {
                Ranking = 100;
                return;
            }
            this.Ranking += rankingForMethod;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";
        }

    }
}

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
                    throw new ArgumentNullException(ExceptionMessages.ManagerNameNull);

                this.name = value;
            }
        }
        public double Ranking { get; protected set; }

        public abstract void RankingUpdate(double updateValue);

        internal void UpdateRanking(double rankingForMethod)
        {
            if( rankingForMethod < 0) rankingForMethod = 0;
            if(rankingForMethod>100) rankingForMethod = 100;

            this.Ranking*=rankingForMethod;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";
        }

    }
}

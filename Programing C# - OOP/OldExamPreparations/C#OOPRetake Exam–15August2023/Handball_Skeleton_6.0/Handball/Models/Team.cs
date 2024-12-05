using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Models
{
    public abstract class Team : ITeam
    {
        private List<IPlayer> players;
        private double overallRating;

        protected Team(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.TeamNameNull);

            Name = name;
            PointsEarned = 0;
            players = new List<IPlayer>();
        }

        public string Name { get; }
        public int PointsEarned { get; private set; }
        public double OverallRating
        {
            get
            {
                if (this.players.Count > 0)
                    return Math.Round(players.Average(p => p.Rating), 2);
                else
                    return 0;
            }
        }
        public IReadOnlyCollection<IPlayer> Players { get => this.players.AsReadOnly(); }

        public void SignContract(IPlayer player) => this.players.Add(player);

        public void Win()
        {
            this.PointsEarned += 3;
            foreach (var player in this.players)
                player.IncreaseRating();
        }
        public void Draw()
        {
            this.PointsEarned += 1;
            foreach (var player in this.players)
            {
                if (player.GetType().Name == nameof(Goalkeeper))
                {
                    player.IncreaseRating();
                }
            }
        }

        public void Lose()
        {
            foreach (var player in this.players)
                player.DecreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.AppendLine($"--Overall rating: {this.OverallRating}");
            
            if(this.Players.Count > 0 )
                sb.AppendLine($"--Players: {string.Join(", ",this.players)}");
            else
                sb.AppendLine($"--Players: none");

            return sb.ToString().Trim();
        }


    }
}

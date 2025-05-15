using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string _nameTeam;
        private readonly List<Player> _players;

        public Team(string nameTeam)
        {
            this.NameTeam = nameTeam;
            this._players = new List<Player>();
        }

        public IReadOnlyCollection<Player> Players => this._players.AsReadOnly();

        public string NameTeam
        {
            get => _nameTeam;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name should not be empty.");
                _nameTeam = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this._players.Count == 0) return 0;
                return _players.Sum(x => x.OverallAvarage);
            }
        }


    public void AddPlayer(Player player, string team)
        {
            if (team != NameTeam) throw new ArgumentException($"Team {team} does not exist.");

            if (!_players.Any(x => x.NamePlayer == player.NamePlayer))
                _players.Add(player);
        }

        public bool RemovePlayer(string playerName)
        {
            if (!_players.Any(x => x.NamePlayer == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.NameTeam} team.");
            }

            Player player = _players.First(x => x.NamePlayer == playerName);
            return _players.Remove(player);
        }

        public override string ToString()
        {

            return $"{this.NameTeam} - {this.Rating}";
        }
    }
}

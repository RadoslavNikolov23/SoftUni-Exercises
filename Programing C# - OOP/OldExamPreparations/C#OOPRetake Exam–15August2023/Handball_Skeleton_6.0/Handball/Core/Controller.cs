using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }


        public string NewTeam(string name)
        {
            ITeam teamToAdd = this.teams.GetModel(name);
            if (teamToAdd != null)
                return string.Format(OutputMessages.TeamAlreadyExists, name, this.teams.GetType().Name);

            teamToAdd = new Team(name);
            this.teams.AddModel(teamToAdd);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, this.teams.GetType().Name);

        }

        public string NewPlayer(string typeName, string name)
        {
            IPlayer playerToAdd = null;

            if (typeName == nameof(Goalkeeper))
                playerToAdd = new Goalkeeper(name);

            else if (typeName == nameof(CenterBack))
                playerToAdd = new CenterBack(name);

            else if (typeName == nameof(ForwardWing))
                playerToAdd = new ForwardWing(name);

            else
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);

            IPlayer playerToFind = this.players.GetModel(name);
            if (playerToFind != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, this.players.GetType().Name, playerToFind.GetType().Name);
            }

            this.players.AddModel(playerToAdd);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);

        }

        public string NewContract(string playerName, string teamName)
        {
            if (!this.players.ExistsModel(playerName))
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));

            if (!this.teams.ExistsModel(teamName))
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));

            IPlayer playerToSight=this.players.GetModel(playerName);
            if(playerToSight.Team != null)
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, playerToSight.Team);

            playerToSight.JoinTeam(teamName);
            ITeam teamWhoSightPlayer=this.teams.GetModel(teamName);
            teamWhoSightPlayer.SignContract(playerToSight);
            return string.Format(OutputMessages.SignContract, playerName, teamWhoSightPlayer.Name);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this.teams.GetModel(firstTeamName);
            ITeam secondTeam = this.teams.GetModel(secondTeamName);

            ITeam teamToWin = firstTeam;
            ITeam teamToLose = secondTeam;

            if(firstTeam.OverallRating == secondTeam.OverallRating)
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);

            }
            else if(firstTeam.OverallRating < secondTeam.OverallRating)
            {
                 teamToWin = secondTeam;
                 teamToLose = firstTeam;
            }

            teamToWin.Win();
            teamToLose.Lose();
            return string.Format(OutputMessages.GameHasWinner, teamToWin.Name, teamToLose.Name);
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            ITeam teamStatic=this.teams.GetModel(teamName);
            List<IPlayer> playerList= teamStatic.Players.OrderByDescending(p=>p.Rating)
                .ThenBy(p=>p.Name).ToList();

            sb.AppendLine($"***{teamName}***");
            foreach (var player in playerList)
                sb.AppendLine(player.ToString());

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb=new StringBuilder();
          
            sb.AppendLine($"***League Standings***");
            foreach(ITeam team in this.teams.Models.OrderByDescending(t=>t.PointsEarned)
                .ThenByDescending(t=>t.OverallRating)
                .ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }



       





       
    }
}

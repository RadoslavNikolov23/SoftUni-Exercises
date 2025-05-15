using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository championship;
        private string[] managerTypes = new string[] { typeof(AmateurManager).Name, typeof(SeniorManager).Name, typeof(ProfessionalManager).Name };

        public Controller()
        {
            this.championship = new TeamRepository();
        }

        public string JoinChampionship(string teamName)
        {
            if (this.championship.Models.Count == this.championship.Capacity)
                return OutputMessages.ChampionshipFull;

            if (this.championship.Exists(teamName))
                return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);

            Team teamToAdd = new Team(teamName);
            this.championship.Add(teamToAdd);
            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);

        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!this.championship.Exists(teamName))
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);

            if (!this.managerTypes.Contains(managerTypeName))
                return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);

            ITeam teamToSign = this.championship.Get(teamName);

            if (teamToSign.TeamManager != null)
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, teamToSign.TeamManager.Name);

            foreach (var teamsInChampionship in this.championship.Models)
            {
                if (teamsInChampionship.TeamManager?.Name == managerName)
                {
                    return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
                }
            }

            IManager manager = GenerateManager(managerTypeName, managerName);
            teamToSign.SignWith(manager);

            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);

        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            if (!this.championship.Exists(teamOneName) || !this.championship.Exists(teamTwoName))
                return string.Format(OutputMessages.OneOfTheTeamDoesNotExist);

            ITeam firstTeam = this.championship.Get(teamOneName);
            ITeam secondTeam = this.championship.Get(teamTwoName);

            ITeam winningTeam = firstTeam;
            ITeam losingTeam = secondTeam;

            if (firstTeam.PresentCondition < secondTeam.PresentCondition)
            {
                winningTeam = secondTeam;
                losingTeam = firstTeam;
            }
            else if (firstTeam.PresentCondition == secondTeam.PresentCondition)
            {
                winningTeam.GainPoints(1);
                losingTeam.GainPoints(1);
                return string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);

            }

            winningTeam.GainPoints(3);
            if (winningTeam.TeamManager != null)
                winningTeam.TeamManager.RankingUpdate(5);

            if (losingTeam.TeamManager != null)
                losingTeam.TeamManager.RankingUpdate(-5);

            return string.Format(OutputMessages.TeamWinsMatch, winningTeam.Name, losingTeam.Name);

        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if (!this.championship.Exists(droppingTeamName))
                return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);

            if (this.championship.Exists(promotingTeamName))
                return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);

            ITeam teamToPromote = new Team(promotingTeamName);

            bool willTeamHaveManager = true;
            if (this.managerTypes.Contains(managerTypeName))
            {
                foreach (var teamInChampionship in this.championship.Models)
                {
                    if (teamInChampionship.TeamManager?.Name == managerName)
                    {
                        willTeamHaveManager = false;
                    }
                }

                if (willTeamHaveManager)
                {
                    IManager manager = GenerateManager(managerTypeName, managerName);
                    teamToPromote.SignWith(manager);
                }
            }

         
            foreach (var teamInChampionship in this.championship.Models)
            {
                teamInChampionship.ResetPoints();
            }

            this.championship.Remove(droppingTeamName);
            this.championship.Add(teamToPromote);
            return string.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);

        }
        public string ChampionshipRankings()
        {
            StringBuilder resultSB = new StringBuilder();
            resultSB.AppendLine("***Ranking Table***");

            List<ITeam> teamsOrderd = this.championship.Models.OrderByDescending(t => t.ChampionshipPoints).ThenByDescending(t => t.PresentCondition).ToList();

            int counter = 1;
            foreach (var teamInChampionship in teamsOrderd)
            {
                resultSB.AppendLine($"{counter++}. {teamInChampionship}/{teamInChampionship.TeamManager}");
            }

            return resultSB.ToString().TrimEnd();

        }

        private IManager GenerateManager(string managerTypeName, string managerName)
        {
            switch (managerTypeName)
            {
                case $"{nameof(AmateurManager)}":
                    return new AmateurManager(managerName);
                    break;
                case $"{nameof(SeniorManager)}":
                    return new SeniorManager(managerName);
                    break;
                case $"{nameof(ProfessionalManager)}":
                    return new ProfessionalManager(managerName);
                    break;
                default: return null;
            }

        }

    }
}

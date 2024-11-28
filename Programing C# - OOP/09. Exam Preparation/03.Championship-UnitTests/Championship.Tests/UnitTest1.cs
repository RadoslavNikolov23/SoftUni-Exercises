using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NuGet.Frameworks;

namespace Championship.Tests
{
    public class Tests
    {
        private League league;

        [SetUp]
        public void SetUpALeague()
        {
            league = new League();
        }

        [Test]
        public void LeagueIsInitializated_Properly()
        {
            League leagueTest = new League();
            Assert.That(leagueTest, Is.Not.Null);
            Assert.That(leagueTest.Capacity, Is.EqualTo(10));
            Assert.That(leagueTest.Teams.Count, Is.EqualTo(0));
        }


        [Test]
        public void LeagueAddmethod_WorksProperly()
        {
            for (int i = 0; i < this.league.Capacity; i++)
            {
                league.AddTeam(new Team(i.ToString()));
                Assert.That(league.Teams.Count, Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void LeagueAddMethod_ThrowsException_WhenTeamCountIsGreatherThanCapacity()
        {
            for (int i = 0; i < this.league.Capacity; i++)
            {
                league.AddTeam(new Team(i.ToString()));
            }

            var exception = Assert.Throws<InvalidOperationException>(() => league.AddTeam(new Team("test")));
            Assert.That(exception.Message, Is.EqualTo("League is full."));
        }

        [Test]
        public void LeagueAddMethod_ThrowsException_WhenTeamAlreadyExsists()
        {
            league.AddTeam(new Team("test"));

            var exception = Assert.Throws<InvalidOperationException>(() => league.AddTeam(new Team("test")));
            Assert.That(exception.Message, Is.EqualTo("Team already exists."));
        }


        [Test]
        public void LeagueRemoveMethod_ReturnsTrueAndRemovesTeam()
        {
            league.AddTeam(new Team("test"));

            bool isRemoved=league.RemoveTeam("test");
            Assert.That(isRemoved, Is.True);
            Assert.That(league.Teams.Count, Is.Zero);
        }

        [Test]
        public void LeagueRemoveMethod_ReturnsFalseAndDosntRemoveTeam()
        {
            league.AddTeam(new Team("test"));

            bool isRemoved=league.RemoveTeam("1");
            Assert.That(isRemoved, Is.False);
            Assert.That(league.Teams.Count, Is.EqualTo(1));
        }


        [Test]
        public void LeaguePlayMatchMethod_WorksCorreclyIfHomeTeamWins()
        {
            string homeTeam = "FirstTeam";
            string awayTeam = "SecondTeam";
            league.AddTeam(new Team(homeTeam));
            league.AddTeam(new Team(awayTeam));

            league.PlayMatch(homeTeam, awayTeam, 1, 0);

            Team homeTeamResult = league.Teams.FirstOrDefault(t => t.Name == homeTeam);
            Team awayTeamResult = league.Teams.FirstOrDefault(t => t.Name == awayTeam);
            Assert.That(homeTeamResult.Wins, Is.EqualTo(1));
            Assert.That(awayTeamResult.Loses, Is.EqualTo(1));
        }

        [Test]
        public void LeaguePlayMatchMethod_WorksCorreclyIfAwayTeamWins()
        {
            string homeTeam = "FirstTeam";
            string awayTeam = "SecondTeam";
            league.AddTeam(new Team(homeTeam));
            league.AddTeam(new Team(awayTeam));

            league.PlayMatch(homeTeam, awayTeam, 0, 3);

            Team homeTeamResult = league.Teams.FirstOrDefault(t => t.Name == homeTeam);
            Team awayTeamResult = league.Teams.FirstOrDefault(t => t.Name == awayTeam);
            Assert.That(homeTeamResult.Loses, Is.EqualTo(1));
            Assert.That(awayTeamResult.Wins, Is.EqualTo(1));
        }

        [Test]
        public void LeaguePlayMatchMethod_WorksCorreclyIfMatchIsADraw()
        {
            string homeTeam = "FirstTeam";
            string awayTeam = "SecondTeam";
            league.AddTeam(new Team(homeTeam));
            league.AddTeam(new Team(awayTeam));

            league.PlayMatch(homeTeam, awayTeam, 0, 0);

            Team homeTeamResult = league.Teams.FirstOrDefault(t => t.Name == homeTeam);
            Team awayTeamResult = league.Teams.FirstOrDefault(t => t.Name == awayTeam);
            Assert.That(homeTeamResult.Draws, Is.EqualTo(1));
            Assert.That(awayTeamResult.Draws, Is.EqualTo(1));
        }


        [Test]
        public void LeaguePlayMatchMethod_ThrowsExceptionIfHomeTeamDoenExist()
        {
            string homeTeam = "FirstTeam";
            string awayTeam = "SecondTeam";
            league.AddTeam(new Team(awayTeam));


            var exception = Assert.Throws<InvalidOperationException>(() => league.PlayMatch(homeTeam, awayTeam, 0, 0));
            Assert.That(exception.Message, Is.EqualTo("One or both teams do not exist."));

        }


        [Test]
        public void LeaguePlayMatchMethod_ThrowsExceptionIfAwayTeamDoenExist()
        {
            string homeTeam = "FirstTeam";
            string awayTeam = "SecondTeam";
            league.AddTeam(new Team(homeTeam));


            var exception = Assert.Throws<InvalidOperationException>(() => league.PlayMatch(homeTeam, awayTeam, 0, 0));
            Assert.That(exception.Message, Is.EqualTo("One or both teams do not exist."));

        }

        [Test]
        public void LeagueGetInfoMethod_WorksCorrecly()
        {
            string testTeam = "testTeam";
            league.AddTeam(new Team(testTeam));

            string output=league.GetTeamInfo(testTeam);

            Assert.That(output, Is.EqualTo($"{testTeam} - {0} points ({0}W {0}D {0}L)"));

        }

        [Test]
        public void LeagueGetInfoMethod_ThrowsException_WhenTeamDoesntExist()
        {
            string testTeam = "testTeam";

            var exception = Assert.Throws<InvalidOperationException>(() => league.GetTeamInfo(testTeam));
            Assert.That(exception.Message, Is.EqualTo("Team does not exist."));

        }


    }
}
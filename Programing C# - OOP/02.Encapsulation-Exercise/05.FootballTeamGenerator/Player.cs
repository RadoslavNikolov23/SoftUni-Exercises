using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string _namePlayer;
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public Player(string namePlayer, int endurance, int sprint, int driblle, int passing, int shooting)
        {
            this.NamePlayer = namePlayer;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = driblle;
            this.Passing = passing;
            this.Shooting = shooting;
        }


        public string NamePlayer
        {
            get => _namePlayer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name should not be empty.");
                _namePlayer = value;
            }
        }
        public int Endurance
        {
            get => _endurance;
            private set
            {
                if (!Validate(value)) throw new ArgumentException("Endurance should be between 0 and 100.");
                _endurance = value;
            }
        }
        public int Sprint
        {
            get => _sprint;
            private set
            {
                if (!Validate(value)) throw new ArgumentException("Sprint should be between 0 and 100.");
                _sprint = value;
            }
        }
        public int Dribble
        {
            get => _dribble;
            private set
            {
                if (!Validate(value)) throw new ArgumentException("Dribble should be between 0 and 100.");
                _dribble = value;
            }
        }

        public int Passing
        {
            get => _passing;
            private set
            {
                if (!Validate(value)) throw new ArgumentException("Passing should be between 0 and 100.");
                _passing = value;
            }
        }

        public int Shooting
        {
            get => _shooting;
            private set
            {
                if (!Validate(value)) throw new ArgumentException("Shooting should be between 0 and 100.");
                _shooting = value;
            }
        }

        public int OverallAvarage => (int)Math.Round((_endurance + _sprint + _passing + _dribble + _shooting) / 5.0);


        private bool Validate(int stat)
        {
            if (stat < 0 || stat > 100) return false;

            return true;
        }

    }
}

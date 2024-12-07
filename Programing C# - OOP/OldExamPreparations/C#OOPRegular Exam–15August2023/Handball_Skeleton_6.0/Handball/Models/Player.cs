using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private double rating;
        public Player(string name, double rating)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException(ExceptionMessages.PlayerNameNull);

            Name = name;
            Rating = rating;
        }

        public string Name { get; }
        public double Rating {
            get
            {
                if (rating > 10)
                    return 10;
                else if (rating < 1)
                    return 1;
                else return rating;
            }
            protected set 
            { 
                if (value > 10) 
                    rating = 10; 
                else if(value < 1)
                    rating = 1;
                else rating = value; 
            } 
        }
        public string Team { get; private set; }


        public void JoinTeam(string name) => this.Team = name;

        public abstract void IncreaseRating();
      
        public abstract void DecreaseRating();

        public override string ToString() => $"{this.GetType().Name}: {this.Name}{Environment.NewLine}--Rating: {this.Rating}";



    }
}

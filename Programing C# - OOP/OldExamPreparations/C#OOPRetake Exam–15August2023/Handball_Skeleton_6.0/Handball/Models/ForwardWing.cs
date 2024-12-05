using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double initialRatingForwardWing = 5.5;

        public ForwardWing(string name) : base(name, initialRatingForwardWing)
        {
        }

        public override void IncreaseRating() => this.Rating += 1.25;
        public override void DecreaseRating() => this.Rating -= 0.75;
    }
}

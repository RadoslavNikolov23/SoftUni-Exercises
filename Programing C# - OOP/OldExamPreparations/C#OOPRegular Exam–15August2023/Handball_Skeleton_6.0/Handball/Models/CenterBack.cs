using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double initialRatingCentralBack = 4;

        public CenterBack(string name) : base(name, initialRatingCentralBack)
        {
        }

        public override void IncreaseRating() => this.Rating += 1;
        public override void DecreaseRating() => this.Rating -= 1;
    }
}

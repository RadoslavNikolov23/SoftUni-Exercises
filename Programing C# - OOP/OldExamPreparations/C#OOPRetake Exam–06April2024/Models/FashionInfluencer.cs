using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double constEngementRateFI = 4.0;
        private const double campaingPriceFactorFI = 0.1;
        public FashionInfluencer(string username, int followers) : base(username, followers, constEngementRateFI)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(base.CalculateCampaignPrice() * campaingPriceFactorFI);
        }
    }
}

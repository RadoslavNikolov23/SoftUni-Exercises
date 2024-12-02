using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private List<string> contributors;

        protected Campaign(string brand, double budget)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException(ExceptionMessages.BrandIsrequired);

            this.Brand = brand;
            this.Budget = budget;
            this.contributors = new List<string>();
        }

        public string Brand { get; }
        public double Budget { get; private set; }
        public IReadOnlyCollection<string> Contributors { get => contributors.AsReadOnly(); }

        public void Gain(double amount)
        {
            this.Budget += amount;
        }

        public void Engage(IInfluencer influencer)
        {
            string usernameOfInfluencer=influencer.Username;
            this.contributors.Add(usernameOfInfluencer);
            this.Budget -= influencer.CalculateCampaignPrice();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {this.Brand}, Budget: {this.Budget}, Contributors: {this.Contributors.Count}";
        }


    }
}

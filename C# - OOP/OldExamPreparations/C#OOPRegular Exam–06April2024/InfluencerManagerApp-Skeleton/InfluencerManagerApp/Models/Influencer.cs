using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private List<string> participations;
        protected Influencer(string username, int followers, double engagementRate)
        {
            if(string.IsNullOrWhiteSpace(username)) 
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);

            if(followers<0) 
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);


            this.Username = username;
            this.Followers = followers;
            this.EngagementRate = engagementRate;
            this.Income = 0;
            this.participations = new List<string>();
        }

        public string Username { get; }
        public int Followers { get; }
        public double EngagementRate { get; }
        public double Income { get; private set; }
        public IReadOnlyCollection<string> Participations { get => this.participations.AsReadOnly(); }

        public void EarnFee(double amount)
        {
           this.Income += amount;
        }

        public void EnrollCampaign(string brand)
        {
            this.participations.Add(brand);
        }

        public void EndParticipation(string brand)
        {
            this.participations.Remove(brand);
        }

        public virtual int CalculateCampaignPrice()
        {
            return (int)(this.Followers * this.EngagementRate);
        }

        public override string ToString()
        {
            return $"{this.Username} - Followers: {this.Followers}, Total Income: {this.Income}";
        }
    }
}

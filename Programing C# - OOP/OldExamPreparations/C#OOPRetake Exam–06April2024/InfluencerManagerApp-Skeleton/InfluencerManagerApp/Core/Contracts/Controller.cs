using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            this.influencers = new InfluencerRepository();
            this.campaigns = new CampaignRepository();
        }


        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            IInfluencer influencerToAdd = null;
            if (nameof(BloggerInfluencer) == typeName)
            {
                influencerToAdd= new BloggerInfluencer(username, followers);
            }
            else if (nameof(BusinessInfluencer) == typeName)
            {
                influencerToAdd= new BusinessInfluencer(username,followers);
            }
            else if (nameof(FashionInfluencer) == typeName)
            {
                influencerToAdd= new FashionInfluencer(username, followers);
            }
            else
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            IInfluencer influencerToMatch = this.influencers.FindByName(username)!;
            if (influencerToMatch != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, this.influencers.GetType().Name);
            }

            this.influencers.AddModel(influencerToAdd);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, influencerToAdd.Username);

        }


        public string BeginCampaign(string typeName, string brand)
        {
            ICampaign campaignToAdd = null;
            if (nameof(ProductCampaign) == typeName)
            {
                campaignToAdd= new ProductCampaign(brand);
            }
            else if (nameof(ServiceCampaign) == typeName)
            {
                campaignToAdd = new ServiceCampaign(brand);
            }
            else
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            ICampaign campaignToMatch=this.campaigns.FindByName(brand);
            if (campaignToMatch != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            this.campaigns.AddModel(campaignToAdd);
            return string.Format(OutputMessages.CampaignStartedSuccessfully,campaignToAdd.Brand,typeName);

        }


        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencerToAttract = this.influencers.FindByName(username);
            if (influencerToAttract == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, this.influencers.GetType().Name, username);
            }

            ICampaign campaignToStart = this.campaigns.FindByName(brand);
            if (campaignToStart == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaignToStart.Contributors.Any(x => x == influencerToAttract.Username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            bool isEligible = IsEligibleTheInfluencerToParticipate(campaignToStart.GetType().Name, influencerToAttract.GetType().Name);

            if (!isEligible)
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaignToStart.Budget < influencerToAttract.CalculateCampaignPrice())
            {
                return String.Format(OutputMessages.UnsufficientBudget, brand, username);
            }


            influencerToAttract.EarnFee(influencerToAttract.CalculateCampaignPrice());  ///TODO ?????????
            campaignToStart.Engage(influencerToAttract); ///TODO ?????????
            influencerToAttract.EnrollCampaign(campaignToStart.Brand);
            return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);


        }


        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaignToFind = this.campaigns.FindByName(brand);
            if (campaignToFind == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaignToFind.Gain(amount);
            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);


        }


        public string CloseCampaign(string brand)
        {
            ICampaign campaignToFind = this.campaigns.FindByName(brand);
            if (campaignToFind == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToClose);
            }

            double campaignBudget = campaignToFind.Budget;

            if (campaignBudget <= 10000)
            {
                return String.Format(OutputMessages.CampaignCannotBeClosed, brand);

            }

            string[] allInfluencersInCamptain = campaignToFind.Contributors.ToArray();
            IInfluencer[] allInfluencers = this.influencers.Models.ToArray();

            foreach (var influencer in allInfluencers)
            {
                if (allInfluencersInCamptain.Contains(influencer.Username))
                {
                    influencer.EarnFee(2000);
                    influencer.EndParticipation(brand);
                }
            }

            this.campaigns.RemoveModel(campaignToFind);
            return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);

           
        }


        public string ConcludeAppContract(string username)
        {
            IInfluencer influencerToFind = this.influencers.FindByName(username);
            if (influencerToFind == null)
            {
                return String.Format(OutputMessages.InfluencerNotSigned,username);
            }

            if (influencerToFind.Participations.Count > 0)
            {
                return String.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            this.influencers.RemoveModel(influencerToFind);
            return String.Format(OutputMessages.ContractConcludedSuccessfully, username);

        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            IInfluencer[] allInfuelncers=this.influencers.Models.OrderByDescending(i=>i.Income)
                .ThenByDescending(i=>i.Followers).ToArray();

            ICampaign[] allCampaigns = this.campaigns.Models.ToArray();

            foreach(var infuelcer in allInfuelncers)
            {
                sb.AppendLine(infuelcer.ToString());
                if (infuelcer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campaighn in infuelcer.Participations.OrderBy(x => x))
                    {
                        foreach (var allcamp in allCampaigns)
                        {
                            if (allcamp.Brand == campaighn)
                            {
                                sb.AppendLine($"--{allcamp}");
                                break;
                            }
                        }
                    }
                }
               
            }

            return sb.ToString().Trim();
        }


        private static bool IsEligibleTheInfluencerToParticipate(string campaignType, string influencerType)
        {
            if (campaignType == nameof(ProductCampaign))
            {
                if (influencerType == nameof(BusinessInfluencer)
                    || influencerType == nameof(FashionInfluencer))
                {
                   return true;
                }
            }
            else if (campaignType == nameof(ServiceCampaign))
            {
                if (influencerType == nameof(BusinessInfluencer)
                   || influencerType == nameof(BloggerInfluencer))
                {
                    return true;
                }
            }

            return false; ;
        }
    }
}

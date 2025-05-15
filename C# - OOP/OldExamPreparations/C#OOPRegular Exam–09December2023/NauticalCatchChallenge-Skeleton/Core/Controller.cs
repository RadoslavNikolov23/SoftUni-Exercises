using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishes;

        public Controller()
        {
            this.divers = new DiverRepository();
            this.fishes = new FishRepository();
        }


        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver diverToAdd = null;
            if (diverType == nameof(FreeDiver))
                diverToAdd = new FreeDiver(diverName);
            
            else if (diverType == nameof(ScubaDiver))
                diverToAdd = new ScubaDiver(diverName);

            else
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);

            IDiver diverToFind = this.divers.GetModel(diverName);
            if (diverToFind != null)
                return string.Format(OutputMessages.DiverNameDuplication, diverName, this.divers.GetType().Name);

            this.divers.AddModel(diverToAdd);
            return string.Format(OutputMessages.DiverRegistered, diverName, this.divers.GetType().Name);
        }


        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish fishToAdd = null;
            if (fishType == nameof(DeepSeaFish))
                fishToAdd = new DeepSeaFish(fishName,points);

            else if (fishType == nameof(PredatoryFish))
                fishToAdd = new PredatoryFish(fishName, points);
            
            else if (fishType == nameof(ReefFish))
              fishToAdd = new ReefFish(fishName, points);
            
            else
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);

            if (this.fishes.GetModel(fishName) != null)
                return string.Format(OutputMessages.FishNameDuplication, fishName,this.fishes.GetType().Name);


            this.fishes.AddModel(fishToAdd);
            return string.Format(OutputMessages.FishCreated, fishName, this.fishes.GetType().Name);
        }


        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diverToChase=this.divers.GetModel(diverName);

            if (diverToChase == null)
                return string.Format(OutputMessages.DiverNotFound,this.divers.GetType().Name, diverName);
            
            IFish fishToChase=this.fishes.GetModel(fishName);

            if (fishToChase == null)
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            

            if (diverToChase.HasHealthIssues)
                return string.Format(OutputMessages.DiverHealthCheck, diverToChase.Name);

            if (diverToChase.OxygenLevel < fishToChase.TimeToCatch)
                return MissTheCatch(fishToChase, diverToChase,diverName,fishName);

            else if (diverToChase.OxygenLevel == fishToChase.TimeToCatch)
            {
                if (isLucky)
                    return HitTheCatch(fishToChase, diverToChase, diverName, fishName);
            
                else
                    return MissTheCatch(fishToChase, diverToChase, diverName, fishName);
            }
            else
                return HitTheCatch(fishToChase, diverToChase, diverName, fishName);
        }


        public string HealthRecovery()
        {
            int counter = 0;
            foreach(IDiver diver in this.divers.Models)
            {
                if (diver.HasHealthIssues == true)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    counter++;
                }
            }
            return string.Format(OutputMessages.DiversRecovered, counter);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diverToReport=this.divers.GetModel(diverName);
            StringBuilder sb=new StringBuilder();
            sb.AppendLine(diverToReport.ToString());

            sb.AppendLine($"Catch Report:");
         
            foreach(var fish in diverToReport.Catch)
            {
                if(this.fishes.Models.Any(f=>f.Name== fish))
                {
                    IFish fishToAdd=this.fishes.GetModel(fish);
                    sb.AppendLine(fishToAdd.ToString());
                }
            }
            return sb.ToString().Trim();
        }


        public string CompetitionStatistics()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            IDiver[] diversStatic=this.divers.Models.OrderByDescending(d=>d.CompetitionPoints)
                .ThenByDescending(d=>d.Catch.Count())
                .ThenBy(d=>d.Name).ToArray();

            foreach(var diver in diversStatic)
            {
                if (!diver.HasHealthIssues)
                    sb.AppendLine(diver.ToString());
            }
            return sb.ToString().Trim();
        }

        private string MissTheCatch(IFish fishToChase, IDiver diverToChase, string diverName, string fishName)
        {
            diverToChase.Miss(fishToChase.TimeToCatch);
            ChechOxygenLevel(diverToChase);
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);
        }
        private string HitTheCatch(IFish fishToChase, IDiver diverToChase, string diverName, string fishName)
        {
            diverToChase.Hit(fishToChase);
            ChechOxygenLevel(diverToChase);
            return string.Format(OutputMessages.DiverHitsFish, diverName, fishToChase.Points, fishName);
        }

        private static void ChechOxygenLevel(IDiver diverToChase)
        {
            if (diverToChase.OxygenLevel == 0)
                diverToChase.UpdateHealthStatus();
        }
    }
}

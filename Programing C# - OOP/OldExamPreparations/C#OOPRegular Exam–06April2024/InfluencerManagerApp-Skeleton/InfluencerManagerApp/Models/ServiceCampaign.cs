﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class ServiceCampaign : Campaign
    {
        private const double budgetServiceCampaign = 30000;

        public ServiceCampaign(string brand) : base(brand, budgetServiceCampaign)
        {
        }
    }
}

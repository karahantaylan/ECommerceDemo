using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Infrastructure
{
    public interface ICampaign
    {
        CampaignModel Add(CampaignModel campaign);
        IEnumerable<CampaignModel> GetAll();
        CampaignModel GetByCampaignName(string campaignName);
        void Update(CampaignModel campaign);
    }
}

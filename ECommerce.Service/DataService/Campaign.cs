using ECommerce.Context;
using ECommerce.Model;
using ECommerce.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Service.DataService
{
    public class Campaign : ICampaign
    {
        private readonly CoreDB _db;

        public Campaign(CoreDB db)
        {
            _db = db;
        }

        public CampaignModel Add(CampaignModel campaign)
        {
            var addedCampaign = _db.Add(campaign);
            _db.SaveChanges();
            campaign.CampaignId = addedCampaign.Entity.CampaignId;

            return campaign;
        }

        public IEnumerable<CampaignModel> GetAll()
        {
            return _db.Campaign.ToList();
        }

        public CampaignModel GetByCampaignName(string campaignName)
        {
            return _db.Campaign.SingleOrDefault(x => x.CampaignName == campaignName);
        }

        public void Update(CampaignModel campaign)
        {
            var updatedCampaign = GetByCampaignName(campaign.CampaignName);
            updatedCampaign.Duration = campaign.Duration;
            updatedCampaign.CampaignName = campaign.CampaignName;
            updatedCampaign.PriceManipulationLimit = campaign.PriceManipulationLimit;
            updatedCampaign.ProductCode = campaign.ProductCode;
            updatedCampaign.TargetSalesCount = campaign.TargetSalesCount;
            updatedCampaign.Status = campaign.Status;

            _db.Update(updatedCampaign);
            _db.SaveChanges();
        }
    }
}

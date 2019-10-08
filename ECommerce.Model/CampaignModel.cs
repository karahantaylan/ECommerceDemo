using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model
{
    public class CampaignModel
    {
        [Key]
        public int CampaignId { get; set; }

        public string CampaignName { get; set; }

        public int ProductCode { get; set; }

        public int Duration { get; set; }

        public int PriceManipulationLimit { get; set; }

        public int TargetSalesCount { get; set; }

        public bool Status { get; set; }

    }
}

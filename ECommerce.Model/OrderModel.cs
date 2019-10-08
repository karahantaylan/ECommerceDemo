using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        public int ProductCode { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int? CampaignId { get; set; }

        public bool Status { get; set; }
    }
}


using ECommerce.Service.Infrastructure;
using ECommerce.Service.DataService;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerce.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaign _campaignRepository;

        public CampaignController(ICampaign campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        // GET api/campaign
        [HttpGet]
        public IEnumerable<CampaignModel> Get()
        {
            return _campaignRepository.GetAll();
        }

        // GET campaign/2
        [HttpGet("{campaignName}", Name = "GetCampaign")]
        public ContentResult Get(string campaignName)
        {
            var campaign = _campaignRepository.GetByCampaignName(campaignName);
            if (campaign == null)
            {
                return Content("No Data");
            }
            return Content("Campaign " + campaign.CampaignName + " info; product " + campaign.ProductCode + ";duration " + campaign.Duration + ";Status " + campaign.Status + ", Target Sales " + campaign.TargetSalesCount + ", limit " + campaign.PriceManipulationLimit);
        }

        // POST campaign
        [HttpPost]
        public ContentResult Post([FromBody]CampaignModel value)
        {
            if (value == null)
            {
                return Content("Bad Request");
            }
            var campaign = _campaignRepository.Add(value);

            return Content("Campaign created; " + campaign.CampaignName + "product " + campaign.ProductCode + ";duration " + campaign.Duration + ";Status " + campaign.Status + ", Target Sales " + campaign.TargetSalesCount + ", limit " + campaign.PriceManipulationLimit);
        }
    }
}

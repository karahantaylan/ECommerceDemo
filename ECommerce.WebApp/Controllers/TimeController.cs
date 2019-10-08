
using ECommerce.Service.Infrastructure;
using ECommerce.Service.DataService;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerce.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITime _timeRepository;

        public TimeController(ITime timeRepository)
        {
            _timeRepository = timeRepository;
        }

        // increase time
        [HttpPost]
        public ContentResult Post([FromBody]int value)
        {
            if (value < 1)
            {
                return Content("Bad Request - Change Parameter");
            }

            var time = _timeRepository.IncreaseTime(value);

            return Content("Time is 0"+ time + ".00" );
        }
    }
}

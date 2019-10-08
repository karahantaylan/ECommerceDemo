using ECommerce.Context;
using ECommerce.Model;
using ECommerce.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Service.DataService
{
    public class Time : ITime
    {
        private readonly ICampaign _campaignRepository;
        private readonly IOrder _orderRepository;
        private readonly IProduct _productRepository;
        private readonly CoreDB _db;

        static int currentTime;

        public Time(CoreDB db, IProduct productRepository, ICampaign campaignRepository, IOrder orderRepository)
        {
            _campaignRepository = campaignRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _db = db;
        }

        public int IncreaseTime(int hour)
        {
            currentTime = currentTime + hour;
            TimeFunction(hour);
            return currentTime;
        }

        //Time creates order. 
        //Every hour means 10 orders. *demandPerHour
        //No need for campaign 
        private void TimeFunction(int hour)
        {
            int demandPerHour = 10;

            //duration check
            foreach (var campaign in _campaignRepository.GetAll())
            {
                if(campaign.Duration < currentTime)
                {
                    campaign.Status = false;
                    _campaignRepository.Update(campaign);
                }
            }

            foreach (var product in _productRepository.GetAll())
            {
                OrderModel order = new OrderModel();
                order.ProductCode = product.ProductCode;
                order.Quantity = hour * demandPerHour;
                _orderRepository.OrderLogic(order);
            }
            
        }
    }
}

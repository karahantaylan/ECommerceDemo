using ECommerce.Context;
using ECommerce.Model;
using ECommerce.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Service.DataService
{
    public class Order : IOrder
    {
        private readonly CoreDB _db;
        private readonly IProduct _productRepository;


        public Order(CoreDB db, IProduct productRepository)
        {
            _db = db;
            _productRepository = productRepository;
        }

        public void Add(OrderModel order)
        {
            OrderLogic(order);
        }

        public IEnumerable<OrderModel> GetAll()
        {
            return _db.Order.ToList();
        }

        public OrderModel GetByOrderId(int orderId)
        {
            return _db.Order.SingleOrDefault(x => x.OrderId == orderId);
        }

        public void OrderLogic(OrderModel order)
        {
            var product = _productRepository.GetByProductCode(order.ProductCode);
            if (product == null)
            {
                //null id
            }
            else
            {
                if (product.Stock > order.Quantity)
                {
                    product.Stock = product.Stock - order.Quantity;
                    order.Status = true;

                    //first campaign picked.
                    var campaign = _db.Campaign.SingleOrDefault(x => x.ProductCode == product.ProductCode && x.Status == true);
                    if (campaign == null)
                    {
                        //productPrice is same.
                        //order has no campaign
                        order.CampaignId = 0;
                    }
                    else
                    {
                        //productPrice decreased with campaign's limit.
                        product.Price = product.Price - (product.Price / campaign.PriceManipulationLimit);
                        order.CampaignId = campaign.CampaignId;
                    }
                    _productRepository.Update(product);
                }
                else
                {
                    //productStock is insufficient.
                    order.Status = false;
                }
                order.Price = product.Price;
                _db.Add(order);
                _db.SaveChanges();
            }
        }
    }
}

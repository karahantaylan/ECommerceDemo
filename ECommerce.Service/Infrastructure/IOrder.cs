using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Infrastructure
{
    public interface IOrder
    {
        void Add(OrderModel order);
        OrderModel GetByOrderId(int orderId);

        IEnumerable<OrderModel> GetAll();
        //void Update(OrderModel order);

        void OrderLogic(OrderModel order);
    }
}

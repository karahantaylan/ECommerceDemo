using ECommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Infrastructure
{
    public interface ITime
    {
        int IncreaseTime(int hour);
    }
}

using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services.Interface
{
    public interface IOrderService :IService<Order>
    {
        Task CreateOrderWithCustomer(Order order, List<OrderDetail> orderDetails, Customer customer);
    }
}

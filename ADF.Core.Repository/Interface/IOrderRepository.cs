using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Data.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task CreateOrderWithCustomer(Order order, List<OrderDetail> orderDetails, Customer customer);
    }
}

using ADF.Core.Data.Interface;
using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ADF.Core.Data
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ADFDbContext _appDbcontext { get => _context as ADFDbContext; }
        public OrderRepository(ADFDbContext context) : base(context)
        {

        }

        public async Task CreateOrderWithCustomer(Order order,List<OrderDetail> orderDetails, Customer customer)
        {
            if(!_appDbcontext.Customers.AnyAsync(c => c.Id == customer.Id && c.Name == customer.Name).Result)
            {
                _appDbcontext.Customers.Add(customer);
            }
            var newOrder = new Order()
            {
                Customer = customer,
                OrderDetails = orderDetails,
                Discount = order.Discount,
                Comments = order.Comments,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
           await _appDbcontext.Orders.AddAsync(newOrder);
        }
    }
}

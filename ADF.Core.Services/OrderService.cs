using ADF.Core.Data;
using ADF.Core.Data.Interface;
using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _repository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task CreateOrderWithCustomer(Order order, List<OrderDetail> orderDetails, Customer customer)
        {
            await _repository.CreateOrderWithCustomer(order, orderDetails, customer);
            await _unitOfWork.CommitAsync();
        }
    }
}

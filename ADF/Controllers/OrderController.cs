using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using ADF.CoreApi.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADF.CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdminRole")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        private readonly IMapper _Mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _OrderService = orderService;
            _Mapper = mapper;
        }

        [HttpPost]
        [Route("/neworder")]
        public async Task<IActionResult> AddOrder(OrderWithDetailsDto orderDetails)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims;
            var newOrder = _Mapper.Map<Order>(orderDetails);
            //var OrderDetails = _Mapper.Map<Order>(orderDetails);
            //await _OrderService.CreateOrderWithCustomer();

            return Ok();
        }
    }
}
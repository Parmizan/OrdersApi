using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrdersApi.Models;
using OrdersApi.Services.Abstract;

namespace OrdersApi.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        //api/orders
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Orders> Get()
        {
            return _ordersService.GetOrders();
        }

        //api/orders/id/{id}
        [HttpGet]
        [Route("api/[controller]/id/{id}")]
        public IEnumerable<Orders> Get(long id)
        {
            return _ordersService.GetOrders()
                .Where(x => x.OxId.ToString().Contains(id.ToString()));
        }

        [HttpPut]
        [Route("api/[controller]/{id}/status/{status}")]
        public void UpdateStatus(long id, string status)
        {
            _ordersService.UpdateOrderStatus(id, status);
        }

        [HttpPut]
        [Route("api/[controller]/{id}/invoicenumber/{num}")]
        public void UpdateInvoiceNumber(long id, int num)
        {
            _ordersService.UpdateOrderInvoiceNumber(id, num);
        }
    }
}
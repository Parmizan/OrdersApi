using OrdersApi.Models;
using OrdersApi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Services.Concrete
{
    public class OrdersService : IOrdersService
    {
        private readonly OrdersDBContext _dBContext = new OrdersDBContext();

        public OrdersService()
        {

        }

        public IQueryable<Orders> GetOrders()
        {
            return (from or in _dBContext.Set<Orders>()
                    select or);
        }

        public void UpdateOrderStatus(long id, string newStatus)
        {
            var order = _dBContext.Orders.FirstOrDefault(x => x.OxId == id);
            var statusId = _dBContext.OrderStatuses.FirstOrDefault(x => x.Name.Trim().ToLower() == newStatus.Trim().ToLower())?.Id;
            if (order != null)
            {
                order.OrderStatus = statusId;

                _dBContext.SaveChanges();
            }
        }

        public void UpdateOrderInvoiceNumber(long id, int newNumber)
        {
            var order = _dBContext.Orders.FirstOrDefault(x => x.OxId == id);
            if (order != null)
            {
                order.InvoiceNumber = newNumber;

                _dBContext.SaveChanges();
            }
        }
    }
}

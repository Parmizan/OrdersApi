using OrdersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Services.Abstract
{
    public interface IOrdersService
    {
        /// <summary>
        /// returns orders query
        /// </summary>
        /// <returns></returns>
        IQueryable<Orders> GetOrders();

        /// <summary>
        /// update order status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStatus"></param>
        void UpdateOrderStatus(long id, string newStatus);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newNumber"></param>
        void UpdateOrderInvoiceNumber(long id, int newNumber);
    }
}

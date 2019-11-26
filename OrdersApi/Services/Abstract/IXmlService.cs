using OrdersApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Services.Abstract
{
    public interface IXmlService
    {
        /// <summary>
        /// Deserialize input stream into T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        T DeserializeXml<T>(Stream stream) where T : class, new();

        /// <summary>
        /// Import ordersXml into databse
        /// </summary>
        /// <param name="ordersXml"></param>
        void Import(OrdersXml ordersXml);
    }
}

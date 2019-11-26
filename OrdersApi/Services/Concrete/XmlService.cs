using OrdersApi.Models;
using OrdersApi.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OrdersApi.Services.Concrete
{
    public class XmlService : IXmlService
    {
        private readonly OrdersDBContext _dBContext = new OrdersDBContext();

        public XmlService()
        {

        }

        public T DeserializeXml<T>(Stream stream) where T : class, new()
        {
            var serializer = new XmlSerializer(typeof(T));

            return (T)serializer.Deserialize(stream);
        }

        public void Import(OrdersXml ordersXml)
        {
            
            using (var transaction = _dBContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var orderXml in ordersXml.Orders)
                    {
                        Import(orderXml);

                        Import(orderXml.BillingAddress, orderXml.Oxid);

                        foreach (var paymentXml in orderXml.Payments)
                            Import(paymentXml, orderXml.Oxid);

                        foreach (var articleXml in orderXml.Articles)
                            Import(articleXml, orderXml.Oxid);

                        _dBContext.SaveChanges();
                    }
                }
                catch
                {
                    _dBContext.Database.RollbackTransaction();
                }
                finally
                {
                    _dBContext.Database.CommitTransaction();
                }
            }            
        }

        private void Import(OrderXml orderXml)
        {
            _dBContext.Orders.Add(new Orders
            {
                OxId = orderXml.Oxid,
                OrderDatetime  = orderXml.Date
            });
        }

        private void Import(BillingAddressXml billingAddressXml, long orderOxId)
        {
            _dBContext.BillingAddresses.Add(new BillingAddresses
            {
                OrderOxId = orderOxId,
                Email = billingAddressXml.Email,
                Fullname = billingAddressXml.FName,
                Country = billingAddressXml.Country?.Geo,
                City = billingAddressXml.City,
                Street = billingAddressXml.Street,
                HomeNumber = billingAddressXml.Number,
                Zip = billingAddressXml.Zip,
            });
        }

        private void Import(PaymentXml paymentXml, long orderOxId)
        {
            _dBContext.Payments.Add(new Payments
            {
                OrderOxId = orderOxId,
                MethodName = paymentXml.Name,
                Amount = paymentXml.Amount
            });
        }

        private void Import(ArticleXml articleXml, long orderOxId)
        {
            _dBContext.Articles.Add(new Articles
            {
                OrderOxId = orderOxId,
                Nomenclature = articleXml.Num,
                Title = articleXml.Title,
                Amount = articleXml.Amount,
                BrutPrice = articleXml.Price,
            });
        }
    }
}

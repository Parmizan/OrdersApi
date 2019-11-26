using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrdersApi.Models
{
    [XmlRoot(ElementName = "country")]
    public class CountryXml
    {
        [XmlElement(ElementName = "geo")]
        public string Geo { get; set; }
    }

    [XmlRoot(ElementName = "billingaddress")]
    public class BillingAddressXml
    {
        [XmlElement(ElementName = "billemail")]
        public string Email { get; set; }

        [XmlElement(ElementName = "billfname")]
        public string FName { get; set; }

        [XmlElement(ElementName = "billstreet")]
        public string Street { get; set; }

        [XmlElement(ElementName = "billstreetnr")]
        public short Number { get; set; }

        [XmlElement(ElementName = "billcity")]
        public string City { get; set; }

        [XmlElement(ElementName = "country")]
        public CountryXml Country { get; set; }

        [XmlElement(ElementName = "billzip")]
        public int Zip { get; set; }
    }

    [XmlRoot(ElementName = "payment")]
    public class PaymentXml
    {
        [XmlElement(ElementName = "method-name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "amount")]
        public decimal Amount { get; set; }
    }

    [XmlRoot(ElementName = "orderarticle")]
    public class ArticleXml
    {
        [XmlElement(ElementName = "artnum")]
        public long Num { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "amount")]
        public int Amount { get; set; }

        [XmlElement(ElementName = "brutprice")]
        public double Price { get; set; }
    }

    [XmlRoot(ElementName = "order")]
    public class OrderXml
    {
        [XmlElement(ElementName = "oxid")]
        public long Oxid { get; set; }

        [XmlElement(ElementName = "orderdate")]
        public DateTime Date { get; set; }

        [XmlElement(ElementName = "billingaddress")]
        public BillingAddressXml BillingAddress { get; set; }

        [XmlArray(ElementName = "payments")]
        [XmlArrayItem(ElementName = "payment")]
        public List<PaymentXml> Payments { get; set; }

        [XmlArray(ElementName = "articles")]
        [XmlArrayItem(ElementName = "article")]
        public List<ArticleXml> Articles { get; set; }
    }

    [XmlRoot(ElementName = "orders")]
    public class OrdersXml
    {
        [XmlElement(ElementName = "order")]
        public List<OrderXml>Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersApi.Models;
using OrdersApi.Services.Abstract;

namespace OrdersApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        private readonly IXmlService _xmlService;

        public XmlController(IXmlService xmlService)
        {
            _xmlService = xmlService;
        }

        //api/xml/orders
        [HttpPost]
        public IActionResult Orders(IFormFile file)
        {
            try
            {
                var orderXml = _xmlService.DeserializeXml<OrdersXml>(file.OpenReadStream());
                _xmlService.Import(orderXml);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error");
            }
        }
    }
}
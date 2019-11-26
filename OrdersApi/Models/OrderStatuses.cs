using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OrdersApi.Models
{
    public partial class OrderStatuses
    {
        public OrderStatuses()
        {
            Orders = new HashSet<Orders>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

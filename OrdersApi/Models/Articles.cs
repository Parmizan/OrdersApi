using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OrdersApi.Models
{
    public partial class Articles
    {
        public int Id { get; set; }
        public long Nomenclature { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public double BrutPrice { get; set; }
        public long OrderOxId { get; set; }

        [JsonIgnore]
        public virtual Orders OrderOx { get; set; }
    }
}

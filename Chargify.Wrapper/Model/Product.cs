﻿using Newtonsoft.Json;

namespace Chargify.Wrapper.Model
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public int ProductId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "accounting_code")]
        public string AccountingCode { get; set; }

        [JsonProperty(PropertyName = "handle")]
        public string Handle { get; set; }

        [JsonProperty(PropertyName = "product_family")]
        public ProductFamily ProductFamily { get; set; } 
    }

}

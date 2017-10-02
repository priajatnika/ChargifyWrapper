using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Model
{
    public class ProductFamily
    {
        [JsonProperty(PropertyName = "id")]
        public int ProductFamilyId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "accounting_code")]
        public string AccountingCode { get; set; }

        [JsonProperty(PropertyName = "handle")]
        public string Handle { get; set; }
    }
}

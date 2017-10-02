using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Model
{
    public class Customer
    {
        [JsonProperty(PropertyName = "id")]
        public int CustomerId { get; set; }
    }
}

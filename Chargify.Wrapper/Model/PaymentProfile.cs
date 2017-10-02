using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Model
{
    public class PaymentProfile
    {
        [JsonProperty(PropertyName = "id")]
        public int PaymentProfileId { get; set; }
    }
}

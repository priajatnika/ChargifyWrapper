using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "errors")]
        public List<string> Errors { get; set; }
    }
}

using Chargify.Wrapper.Model;
using System.Collections.Generic;

namespace Chargify.Wrapper.Response
{
    public class PaymentProfilesResponse : IResponseBase<List<PaymentProfile>>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public List<PaymentProfile> Model { get; set; } = new List<PaymentProfile>();
    }
}

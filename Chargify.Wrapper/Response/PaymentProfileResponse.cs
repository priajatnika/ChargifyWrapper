using Chargify.Wrapper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class PaymentProfileResponse : IResponseBase<PaymentProfile>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public PaymentProfile Model { get; set; }
    }
}

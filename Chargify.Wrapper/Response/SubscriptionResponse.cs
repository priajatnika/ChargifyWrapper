using Chargify.Wrapper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class SubscriptionResponse : IResponseBase<Subscription>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public Subscription Model { get; set; }
    }
}

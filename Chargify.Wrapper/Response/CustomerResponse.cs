using Chargify.Wrapper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class CustomerResponse : IResponseBase<Customer>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public Customer Model { get; set; }
    }
}

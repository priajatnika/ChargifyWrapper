using Chargify.Wrapper.Model;
using System.Collections.Generic;

namespace Chargify.Wrapper.Response
{
    public class CustomersResponse : IResponseBase<List<Customer>>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public List<Customer> Model { get; set; } = new List<Customer>();
    }
}

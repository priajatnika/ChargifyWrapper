using Chargify.Wrapper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class ProductResponse : IResponseBase<Product>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public Product Model { get; set; }
    }
}

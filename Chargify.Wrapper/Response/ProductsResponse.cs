using Chargify.Wrapper.Model;
using System.Collections.Generic;

namespace Chargify.Wrapper.Response
{
    public class ProductsResponse : IResponseBase<List<Product>>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public List<Product> Model { get; set; } = new List<Product>();
    }
}

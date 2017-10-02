using Chargify.Wrapper.Model;
using System.Collections.Generic;

namespace Chargify.Wrapper.Response
{
    public class ComponentsResponse : IResponseBase<List<Component>>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public List<Component> Model { get; set; } = new List<Component>();
    }
}

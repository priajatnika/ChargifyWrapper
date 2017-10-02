using Chargify.Wrapper.Model;
using System.Collections.Generic;

namespace Chargify.Wrapper.Response
{
    public class ComponentResponse : IResponseBase<Component>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public Component Model { get; set; }
    }
}

using Chargify.Wrapper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class PricePointResponse : IResponseBase<PricePoint>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public PricePoint Model { get; set; }
    }
}

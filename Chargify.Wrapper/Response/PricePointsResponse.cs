using Chargify.Wrapper.Model;
using System.Collections.Generic;

namespace Chargify.Wrapper.Response
{
    public class PricePointsResponse : IResponseBase<List<PricePoint>>
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public List<PricePoint> Model { get; set; } = new List<PricePoint>();
    }
}

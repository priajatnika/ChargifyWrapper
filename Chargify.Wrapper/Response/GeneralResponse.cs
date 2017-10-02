using System;
using System.Collections.Generic;
using System.Text;

namespace Chargify.Wrapper.Response
{
    public class GeneralResponse<T> : IResponseBase<T> where T : class
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public T Model { get; set; }
    }
}

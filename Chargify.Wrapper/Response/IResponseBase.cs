namespace Chargify.Wrapper.Response
{
    public interface IResponseBase<T> where T : class
    {
        bool IsError { get; set; }
        string Message { get; set; }
        T Model { get; set; }
    }
}

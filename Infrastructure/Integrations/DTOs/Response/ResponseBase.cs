namespace Infrastructure.Integrations.DTOs.Response
{
    public class ResponseBase<T> where T: class
    {
        public T Response { get; set; }
        public bool HasError { get; set; }
    }
}
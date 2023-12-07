namespace ThucTap.Payloads.Responses
{
    public class Responses<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Responses() { }
        public Responses(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public Responses<T> ResponseSuccess(string message, T data)
        {
            return new Responses<T>(StatusCodes.Status200OK, message, data);
        }
        public Responses<T> ResponseError(int status, string message, T data)
        {
            return new Responses<T>(status, message, data);
        }
    }
}

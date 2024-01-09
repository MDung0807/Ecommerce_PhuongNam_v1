namespace Ecommerce_PhuongNam_v1.Application.Common.Responses
{
    
    public class Response<T>
    {
        public bool IsError { get; set; }
        public T Data { get; set; }
        public string DateTime { get; set; }

        public Response(bool isError, T data)
        {
            this.IsError = isError;
            this.Data = data;
            this.DateTime = (System.DateTime.Now).ToString("dd/MM/yyyy hh:mm tt");
        }
    }
}

namespace Rainfall.Api.Domain.Settings
{
    public class ApiErrorSetting
    {
        public string Message { get; set; }
    }

    public class ApiErrorSetting<T> 
    {
        public string Message { get; set; }
        public T Details { get; set; }
    }
}

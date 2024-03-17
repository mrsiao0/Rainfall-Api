namespace Rainfall.Api.Domain.Settings
{
    public class ApiErrorSetting : Exception
    {
        public string Message { get; set; }
    }

    public class ApiErrorSetting<T> : Exception
    {
        public string Message { get; set; }
        public T Details { get; set; }
    }
}

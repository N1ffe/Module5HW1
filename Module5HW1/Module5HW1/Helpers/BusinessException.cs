namespace Module5HW1.Helpers
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public BusinessException(string statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
        public string? StatusCode { get; set; }
    }
}

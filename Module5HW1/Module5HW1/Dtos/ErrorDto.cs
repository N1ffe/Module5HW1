using Newtonsoft.Json;

namespace Module5HW1.Dtos
{
    public class ErrorDto
    {
        [JsonProperty(PropertyName = "error")]
        public string Message { get; set; }
    }
}

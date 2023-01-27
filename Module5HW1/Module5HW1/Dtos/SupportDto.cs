using Newtonsoft.Json;

namespace Module5HW1.Dtos
{
    public class SupportDto
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}

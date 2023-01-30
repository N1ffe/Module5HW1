using Newtonsoft.Json;

namespace Module5HW1.Dtos
{
    public class AuthenticationDto
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}

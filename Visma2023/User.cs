using Newtonsoft.Json;

namespace Visma2023
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
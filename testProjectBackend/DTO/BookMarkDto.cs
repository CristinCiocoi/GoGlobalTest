using Newtonsoft.Json;

namespace testProjectBackend.DTO
{
    public class BookMarkDto
    {
        [JsonProperty("name")]
        public string NameRepository { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; } 
    }
}
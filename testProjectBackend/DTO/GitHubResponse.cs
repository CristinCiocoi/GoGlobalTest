using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace testProjectBackend.DTO
{
    [JsonObject]
    public class GitHubResponse
    {
        [JsonProperty("items")]
        public IEnumerable<ItemRepository> items { get; set; }
    }

    [JsonObject]
    public class ItemRepository
    {
        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("description")]
        public string description { get; set; }
        
        [JsonProperty("owner")]
        public Owner owner { get; set; }
        
    }

    [JsonObject]
    public class Owner
    {
        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }
    }
}
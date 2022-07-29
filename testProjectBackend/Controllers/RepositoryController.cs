using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using testProjectBackend.DTO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace testProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoryController : Controller
    {

        public RepositoryController()
        {}

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepository([FromQuery(Name = "keyword")] string keyword)
        {
            string url = $"https://api.github.com/search/repositories?q={keyword}";
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = WebRequestMethods.Http.Get;
            webRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Accept = "application/json";
            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "BlackHole";

            var response = (HttpWebResponse)webRequest.GetResponse();
            using var dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            var jsonToObject = JsonSerializer.Deserialize<GitHubResponse>(responseFromServer, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return Ok(jsonToObject);
        }
    }
}
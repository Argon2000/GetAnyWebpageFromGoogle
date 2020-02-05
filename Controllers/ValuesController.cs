using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GetAnyWebpage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        // GET api/website
        [HttpGet("{url}")]
        [EnableCors("AllowMyOrigin")]
        public async Task<ActionResult<string>> Get(string url)
        {
            url = "https://" + url;
            url = HttpUtility.UrlDecode(url);
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}

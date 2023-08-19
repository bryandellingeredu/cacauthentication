using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CACAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetUserInfo()
        {
            string token = Request.Headers["Authorization"].ToString().Split(' ')[1];

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/me");
                var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            }
        }
    }
}


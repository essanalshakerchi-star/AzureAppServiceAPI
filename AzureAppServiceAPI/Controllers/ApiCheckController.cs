using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureAppServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoot()
        {
            return Ok(new { message = "Krya på dig fredrik" });
        }
    }
}
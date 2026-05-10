using Microsoft.AspNetCore.Mvc;

namespace AzureAppServiceAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoot()
        {
            return Ok(new { message = "Welcome to Azure App Service API", version = "1.0" });
        }
    }
}
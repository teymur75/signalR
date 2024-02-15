using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly TestBusiness _business;

        public HomeController(TestBusiness business)
        {
            _business = business;
        }


        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _business.SendMessageAsync(message);
            return Ok();
        }
    }
}

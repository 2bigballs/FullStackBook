using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       
        [HttpGet]
        [Route("get")]
        public string Get()
        {
            return "Vitalidk";
        }
    }
}

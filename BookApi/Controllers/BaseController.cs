using System.Net;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult Response<T>(Response<T> response) =>
            response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response.Value),
                HttpStatusCode.Created => Created("", response.Value),
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.NotFound => NotFound(response.Message),
                HttpStatusCode.BadRequest => BadRequest(response.Message),
                _ => StatusCode((int)response.StatusCode,response.Message)
            };
    }
}

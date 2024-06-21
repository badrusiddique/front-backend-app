using Microsoft.AspNetCore.Mvc;

namespace Sample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected ActionResult<T> OkOrNotFound<T>(T item) => item == null ? (ActionResult)NotFound() : Ok(item);
    }
}
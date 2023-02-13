using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] // Ignore for Swagger doc
    public class ErrorController : BaseApiController
    {
        // No have HTTP method for action
        // Ambigous for Swagger when listing Endpoint on documentation
        public IActionResult Error(int code)
            => new ObjectResult(new ApiResponse(code));
    }
}
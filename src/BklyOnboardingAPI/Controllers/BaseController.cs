using BklyOnboardingAPI.Domain.Shared.Responses;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace BklyOnboardingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowEverything")]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

        protected bool IsAuthorized;

        public BaseController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            //_requestID = _contextAccessor.HttpContext.Request.Headers["x-RequestID"];
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ApiUnauthorized(string message = "Unauthorized")
        {
            var r = new ResponseDto<object>
            {
                Code = "01",
                Message = message,
                Data = null,
                Errors = null
            };
            return Unauthorized(r);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ApiBad(ModelStateDictionary modelState = null, [FromQuery] List<string> errors = null, string message = "A required parameter is missing from the input. See errors")
        {
            var modelErrors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            var r = new ResponseDto<object>
            {
                Code = "04",
                Message = modelState is null ? message : modelErrors[0],
                Data = null,
                Errors = modelState is null ? errors is not null ? errors : null : modelErrors
            };

            return BadRequest(r);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected IActionResult ApiOk<T>(T obj, string message = "SUCCESS", string code = "00")
        {
            var r = new ResponseDto<T>
            {
                Code = code,
                Message = message,
                Data = obj,
                Errors = null
            };
            return Ok(r);
        }
    }
}

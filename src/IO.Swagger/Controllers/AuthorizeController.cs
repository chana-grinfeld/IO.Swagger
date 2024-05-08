using ArithmeticExecuteServices.Models;
using ArithmeticExecuteServices.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ArithmeticExecute.Controllers
{
    [AllowAnonymous]
    public class AuthorizeController : ApiController
    {
        private readonly IAuthorizeService _authorizeService;

        public AuthorizeController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [HttpPost]
        [Route("/v1/Authorize")]
        [SwaggerOperation("ReqestLogin")]
        public string ReqestLogin([FromBody] AuthorizeModel request)
        {
            var result = _authorizeService.AuthorizeFunc(request);
            return result;
        }
    }
}
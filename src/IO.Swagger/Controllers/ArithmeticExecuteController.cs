using Microsoft.AspNetCore.Mvc;
using IO.Swagger.Models;
using System.Web.Http;
using ArithmeticExecuteServices.Services.Interfaces;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using ArithmeticExecute.Attributes;

namespace IO.Swagger.Controllers
{
    [JWTAttribute]
    public class ArithmeticExecuteController : ApiController
    {
        private readonly IArithmeticExecuteService _arithmeticExecutService;

        public ArithmeticExecuteController(IArithmeticExecuteService arithmeticExecutService)
        {
            _arithmeticExecutService = arithmeticExecutService;
        }

        [HttpPost]
        [Route("/v1/calculate")]
        [SwaggerOperation("ArithmeticExecuteFunc")]
        public int ArithmeticExecuteFunc([FromBody] ArithmeticExecuteModel request, [FromHeader][Required()] string operationRequest)
        {
            var result = _arithmeticExecutService.ArithmeticExecute(request, operationRequest);
            return result;
        }
    }
}
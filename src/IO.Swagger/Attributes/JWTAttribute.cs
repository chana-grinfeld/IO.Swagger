using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ArithmeticExecuteServices.Models;

namespace ArithmeticExecute.Attributes
{
    public class JWTAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _authorizeModel = context.HttpContext
           .RequestServices
           .GetService(typeof(AuthorizeModel)) as AuthorizeModel;

            if (context.HttpContext.Request.Headers["Authorization"].FirstOrDefault() != null)
            {
                var bearerToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (bearerToken is null)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(bearerToken);

                }
                catch (Exception)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
            else
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
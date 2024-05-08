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

                //TODO: health check
                //When there is a DB, the token must be saved to the DB and then proper checks can be performed on it,
                //for example if it actually exists, 
                //If the token the customer enters is the same as the token sent to him from the system
                //as well as a time check, if the time specified in the token has passed and the user is still present, access to the service must be extended

                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(bearerToken);

                }
                catch (Exception)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
                //var SplitedCleims = jwtSecurityToken.Claims.First(claim => claim.Type == "Name").Value;
            }
            else
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
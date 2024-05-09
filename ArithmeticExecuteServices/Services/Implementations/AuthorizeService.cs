using ArithmeticExecuteServices.Models;
using ArithmeticExecuteServices.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Moq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ArithmeticExecuteServices.Services.Implementations
{
    //After setting authorization, the attribute activates AllowAnonymous on the entire class
    //Removes Authorize from this class so that it is possible to log in
    [AllowAnonymous]
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IConfiguration _configuration;

        public AuthorizeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //ReqestLogin
        [HttpPost]
        [Route("/v1/Authorize")]
        public string AuthorizeFunc([FromBody] AuthorizeModel loginModel)
        {
            if (loginModel.UserName == "Admin" && loginModel.Password == "123")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //Create an identity for the token, with the name "Admin" as given.That is,
                    //the token will contain such user information.
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "Admin")
                }),
                    //defined that the token will expire within one hour from the current time according to UTC.
                    //This is a mechanism to limit the lifetime of the token and prevent its use after its expiration.
                    Expires = DateTime.UtcNow.AddHours(1),
                    //Here a signing process is defined for the token,
                    //by creating a SigningCredentials value that uses a symmetric key(of type SymmetricSecurityKey)
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return tokenString;
            }
            throw new ArgumentException("Unauthorized.");
        }
    }
}
using ArithmeticExecuteServices.Models;
using ArithmeticExecuteServices.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
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
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "Admin")
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
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
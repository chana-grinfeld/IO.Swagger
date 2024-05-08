using ArithmeticExecuteServices.Models;
using ArithmeticExecuteServices.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
                var claims = new List<Claim>()
                {new Claim(ClaimTypes.Name, "Admin")};
                var secretKey = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(secretKey);
                }
                var symmetricKey = new SymmetricSecurityKey(secretKey);
                var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(10),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return tokenString;
            }
            throw new ArgumentException("Unauthorized.");
        }
    }
}
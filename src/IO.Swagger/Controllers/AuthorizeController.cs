using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using ArithmeticExecuteServices.Models;
using System.Security.Cryptography;

namespace ArithmeticExecute.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorizeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthorizeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("/v1/Authorize")]
        public IActionResult AuthorizeFunc([FromBody] AuthorizeModel loginModel)
        {
            if (loginModel.UserName == "Admin" && loginModel.Password == "123")
            {
                var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "Admin")};
                var secretKey = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(secretKey);
                }
                var symmetricKey = new SymmetricSecurityKey(secretKey);
                var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration.GetValue<string>("JWT:Issuer"),
                    audience: _configuration.GetValue<string>("JWT:Audience"),
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(10),
                    signingCredentials: signingCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
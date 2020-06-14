using BookStore.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.JWT
{
    public class JWTHelper
    {
        private IConfiguration _configuration;
        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JwtManagerResponseModel CreateToken(string email, string userId)
        {
            var claims = new[]
            {
                new Claim("Email",email),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken
                (issuer: _configuration["AuthSettings:Issuer"],
                 audience: _configuration["AuthSettings:Audience"],
                 claims: claims,
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtManagerResponseModel
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }
    }
}

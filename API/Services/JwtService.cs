using API.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class JwtService
    {
        private IConfiguration config;

        public JwtService(IConfiguration config)
        {
            this.config = config;
        }

        public string GenerateSecurityToken(Login result)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Username", result.UserName));
            foreach (var item in result.Roles)
            {
                claims.Add(new Claim("roles", item.Name));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:secret"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                config["JwtConfig:Issuer"],
                config["JwtConfig:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
                );
            var idToken = new JwtSecurityTokenHandler().WriteToken(token);
            return idToken;
        }
    }
}

﻿using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        //[HttpGet("{roles}")]
        /*public string GetRandomToken(string roles)
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken("fake@gmail.com", roles);
            return token;
        }*/
    }
}

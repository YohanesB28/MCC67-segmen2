using API.Repositories.Data;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        private IConfiguration config;

        public AccountController(AccountRepository accountRepository, IConfiguration config)
        {
            this.accountRepository = accountRepository;
            this.config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post(Login login)
        {
            var result = accountRepository.Get(login.UserName, login.Password);
            var jwt = new JwtService(config);
            if (result != null)
            {
                var idToken = jwt.GenerateSecurityToken(result);
                return Ok(new { status = 200, data = result, token = idToken });
            }
            else
            {
                return BadRequest(new { status = 400, message = "Request is invalid" });
            }
        }
    }
}

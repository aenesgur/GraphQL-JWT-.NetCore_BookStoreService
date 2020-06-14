using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.JWT;
using BookStore.Entities.Models;
using BookStore.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _configuration;
        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entryText = "Hello, welcome to my GraphQL sample app. To get token, firstly register after that login to server :))";
            return Ok(entryText);
        }

        // /api/authentication/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await _userService.RegisterAsync(model);
                if (registerResult.IsSuccess)
                    return Ok(registerResult);

                return BadRequest(registerResult);
            }

            return BadRequest("Some properties are not valid");
        }

        // /api/authentication/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _userService.LoginAsync(model);
                if (!loginResult.IsSuccess)
                    return BadRequest(loginResult);

                var jwtHelper = new JWTHelper(_configuration);
                var tokenResult = jwtHelper.CreateToken(loginResult.Email, loginResult.UserId);

                if (!tokenResult.IsSuccess)
                    return BadRequest(tokenResult);

                return Ok(tokenResult);
            }

            return BadRequest("Some properties are not valid");
        }
    }
}
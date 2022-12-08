using System;
using Blog.Data.Abstract;
using Blog.Model;
using IdentityService.Services.Abstraction;
using IdentityService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService authService;
        IUserRepository userRepository;
        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            this.authService = authService;
            this.userRepository = userRepository;
        }

        [HttpPost("login")]
        public ActionResult<ExtentedAuthData> Post([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.GetSingle(u => u.Email == model.Email);

            if (user == null)
            {
                return BadRequest(new { email = "no user with this email" });
            }

            var passwordValid = authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid)
            {
                return BadRequest(new { password = "invalid password" });
            }

            var authData = authService.GetAuthData(user.Id);
            ExtentedAuthData extentedAuthData = new ExtentedAuthData
            {
                Token = authData.Token,
                TokenExpirationTime = authData.TokenExpirationTime,
                Id = authData.Id,
                Username = user.Username,
                Email = user.Email
            };
            return extentedAuthData;
        }
        
        [HttpPost("register")]
        public ActionResult<ExtentedAuthData> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = userRepository.isEmailUniq(model.Email);
            if (!emailUniq) return BadRequest(new { email = "user with this email already exists" });
            var usernameUniq = userRepository.IsUsernameUniq(model.Username);
            if (!usernameUniq) return BadRequest(new { username = "user with this email already exists" });

            var id = Guid.NewGuid().ToString();
            var user = new User
            {
                Id = id,
                Username = model.Username,
                Email = model.Email,
                Password = authService.HashPassword(model.Password)
            };
            userRepository.Add(user);
            userRepository.Commit();

                var authData = authService.GetAuthData(id);
                ExtentedAuthData extentedAuthData = new ExtentedAuthData
                {
                    Token = authData.Token,
                    TokenExpirationTime = authData.TokenExpirationTime,
                    Id = authData.Id,
                    Username = user.Username,
                    Email = user.Email
                };
                return extentedAuthData;
        }
    }
}
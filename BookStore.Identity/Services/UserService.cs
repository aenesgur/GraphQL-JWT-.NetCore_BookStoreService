using BookStore.Entities.Models;
using BookStore.Identity.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Identity.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<LoginManagerResponseModel> LoginAsync(LoginModel model)
        {
            if (model == null)
                throw new NullReferenceException("Login Model is null");

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new LoginManagerResponseModel
                {
                    Message = "There is no user with that Email adress",
                    IsSuccess = false
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return new LoginManagerResponseModel
                {
                    Message = "Invalid password",
                    IsSuccess = false
                };
            }

            return new LoginManagerResponseModel
            {
                Message = "Login Succesfull",
                IsSuccess = true,
                UserId = user.Id,
                Email = user.Email
            };
        }

        public async Task<RegisterManagerResponseModel> RegisterAsync(RegisterModel model)
        {
            if (model == null)
                throw new NullReferenceException("Register Model is null");

            if (model.Password != model.Password)
                return new RegisterManagerResponseModel
                {
                    Message = "Confirm password does not match",
                    IsSuccess = false
                };

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                return new RegisterManagerResponseModel
                {
                    Message = "User created succesfully",
                    IsSuccess = true
                };
            }
            return new RegisterManagerResponseModel
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }
    }
}

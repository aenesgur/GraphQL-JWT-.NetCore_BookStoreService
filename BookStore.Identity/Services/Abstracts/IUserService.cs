using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Identity.Services.Abstracts
{
    public interface IUserService
    {
        Task<RegisterManagerResponseModel> RegisterAsync(RegisterModel model);
        Task<LoginManagerResponseModel> LoginAsync(LoginModel model);
    }
}

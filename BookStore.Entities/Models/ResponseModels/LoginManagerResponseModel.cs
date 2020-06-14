using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Entities.Models
{
    public class LoginManagerResponseModel : UserManagerResponseModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Entities.Models
{
    public class RegisterManagerResponseModel : UserManagerResponseModel
    {
        public DateTime? ExpireDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Entities.Models
{
    public class JwtManagerResponseModel : UserManagerResponseModel
    {
        public DateTime? ExpireDate { get; set; }
    }
}

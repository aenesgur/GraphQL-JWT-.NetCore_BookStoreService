using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Entities.Models
{
    public class UserManagerResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

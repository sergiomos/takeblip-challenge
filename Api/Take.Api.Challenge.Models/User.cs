using System;
using System.Collections.Generic;
using System.Text;

namespace Take.Api.Challenge.Models
{
    public class User
    {
        public int Id { get ; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

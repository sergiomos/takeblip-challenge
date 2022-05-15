using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Take.Api.Challenge.Models.Requests
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Take.Api.Challenge.Models;

namespace Take.Api.Challenge.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, Username = "admin", Password = "admin123", Role = "admin" });
            users.Add(new User { Id = 2, Username = "user", Password = "user123", Role = "user" });

            User foundUser = users
                .FirstOrDefault(x => 
                x.Username == username
                && x.Password == password);


            return foundUser;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace LogIn.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    
                    Password = "1111",
                    Role = "Student",
                    SecurityLevel = 4,
                    UserName = "Coi"
                },
                new User
                {
                   
                    Password = "4444",
                    Role = "Student",
                    SecurityLevel = 2,
                    UserName = "Scaca"
                }
            }.ToList();
        }
        
        
        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Builder
{
    class UserBuilder
    {

        private User user;

        public UserBuilder()
        {
            user = new User();
            user.Id = Guid.NewGuid();
            user.LastAccess = DateTime.Now;
        }

        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }

        public UserBuilder SetSurname(string surName)
        {
            user.Surname = surName;
            return this;
        }

        public UserBuilder SetLogin(string login)
        {
            user.Login = login;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            user.Email = email;
            return this;
        }

        public User create()
        {
            return user;
        }

    }
}

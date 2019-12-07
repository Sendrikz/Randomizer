using RandomizerLib.Model;
using System;

namespace RandomizerLib.Builder
{
    class UserBuilder
    {

        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetUpGuid()
        {
            user.Id = Guid.NewGuid();
            return this;
        }

        public UserBuilder SetUpLastAccess()
        {
            user.LastAccess = DateTime.Now;
            return this;
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

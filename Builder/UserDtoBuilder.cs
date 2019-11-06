using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Builder
{
    class UserDtoBuilder
    {

        private UserDto user;

        public UserDtoBuilder()
        {
            user = new UserDto();
        }

        public UserDtoBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }

        public UserDtoBuilder SetSurname(string surName)
        {
            user.Surname = surName;
            return this;
        }

        public UserDtoBuilder SetLogin(string login)
        {
            user.Login = login;
            return this;
        }

        public UserDtoBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }

        public UserDtoBuilder SetEmail(string email)
        {
            user.Email = email;
            return this;
        }

        public UserDtoBuilder SetLastAccess(DateTime time)
        {
            user.LastAccess = time;
            return this;
        }

        public UserDto create()
        {
            return user;
        }
    }
}

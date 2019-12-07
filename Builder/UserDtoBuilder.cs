
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

        public UserDto create()
        {
            return user;
        }
    }
}

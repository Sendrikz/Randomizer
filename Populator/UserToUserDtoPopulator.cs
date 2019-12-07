using RandomizerLib.Builder;
using RandomizerLib.Model;

namespace RandomizerLib.Populator
{
    class UserToUserDtoPopulator
    {

        public UserDto Populate(User user)
        {
            return new UserDtoBuilder()
                .SetEmail(user.Email)
                .SetLogin(user.Login)
                .SetName(user.Name)
                .SetPassword(user.Password)
                .SetSurname(user.Surname)
                .create();
        }
    }
}

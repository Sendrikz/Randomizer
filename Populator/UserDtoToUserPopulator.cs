using RandomizerLib.Builder;
using RandomizerLib.Model;

namespace RandomizerLib.Populator
{
    public class UserDtoToUserPopulator
    {
        public User Populate(UserDto userDto)
        {
            return new UserBuilder()
                .SetEmail(userDto.Email)
                .SetLogin(userDto.Login)
                .SetName(userDto.Name)
                .SetPassword(userDto.Password)
                .SetSurname(userDto.Surname)
                .SetUpGuid()
                .SetUpLastAccess()
                .create();
        }
    }
}

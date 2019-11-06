using RandomizerLib.Builder;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Populator
{
    public class UserDtoToUserPopulator
    {
        public User populate(UserDto userDto)
        {
            return new UserBuilder()
                .SetEmail(userDto.Email)
                .SetLogin(userDto.Login)
                .SetName(userDto.Name)
                .SetPassword(userDto.Password)
                .SetSurname(userDto.Surname)
                .create();
        }
    }
}

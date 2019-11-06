using RandomizerLib.Builder;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Populator
{
    class UserToUserDtoPopulator
    {

        public UserDto populate(User user)
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

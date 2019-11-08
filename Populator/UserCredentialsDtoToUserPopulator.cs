using RandomizerLib.Dto;
using RandomizerLib.Model;
using RandomizerLib.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Populator
{
    class UserCredentialsDtoToUserPopulator
    {

        public User populate(UserCredentialsDto user)
        {
            return new UserBuilder()
                .SetLogin(user.Login)
                .SetPassword(user.Password)
                .create();
        }
    }
}

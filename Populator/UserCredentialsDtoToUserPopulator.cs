using RandomizerLib.Dto;
using RandomizerLib.Model;
using RandomizerLib.Builder;

namespace RandomizerLib.Populator
{
    class UserCredentialsDtoToUserPopulator
    {

        public User Populate(UserCredentialsDto user)
        {
            return new UserBuilder()
                .SetLogin(user.Login)
                .SetPassword(user.Password)
                .create();
        }
    }
}

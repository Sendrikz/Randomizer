using RandomizerLib.Dto;
using RandomizerLib.Exception;
using RandomizerLib.Model;
using RandomizerLib.Populator;
using System;
using System.ServiceModel;

namespace RandomizerLib
{
    public class Service1 : IService1
    {

        UserDao userDao = new UserDao();
        UserDtoToUserPopulator userDtoToUser = new UserDtoToUserPopulator();
        UserToUserDtoPopulator userToUserDto = new UserToUserDtoPopulator();
        UserCredentialsDtoToUserPopulator UserCredentialsDtoToUser = new UserCredentialsDtoToUserPopulator();

        public UserDto CheckCredentials(UserCredentialsDto user)
        {
            User userToCheck = UserCredentialsDtoToUser.populate(user);
            User resultedUser; 

            try
            {
               resultedUser = userDao.GetLogined(userToCheck);
            }
            catch(System.Exception e)
            {
                throw new FaultException<NoSuchUserException>(new NoSuchUserException(), e.Message);
            }

            return userToUserDto.populate(resultedUser);
        }

        public bool ExistUser(string login)
        {
            try
            {
                userDao.GetUserByLogin(login);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }


        public void RegisterUser(UserDto user)
        {
            User userToAdd = userDtoToUser.populate(user);

            userDao.CreateUser(userToAdd);
        }

        public void UserHistory(string login)
        {
            throw new NotImplementedException();
        }

        public void SaveHistory(HistoryDto history)
        {
            throw new NotImplementedException();
        }
    }
}

using RandomizerLib.Dto;
using RandomizerLib.Exception;
using RandomizerLib.Model;
using RandomizerLib.Populator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
                throw new FaultException<Fault>(new Fault(e.Message));
            }

            return userToUserDto.populate(resultedUser);
        }

        public UserDto GetUser(string login)
        {
            User findedUser = userDao.GetUserByLogin(login);

            return userToUserDto.populate(findedUser);
        }


        public bool RegisterUser(UserDto user)
        {
            User userToAdd = userDtoToUser.populate(user);

            userDao.CreateUser(userToAdd);

            return true;
        }
    }
}

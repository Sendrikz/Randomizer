using RandomizerLib.Dao;
using RandomizerLib.Dto;
using RandomizerLib.Exception;
using RandomizerLib.Model;
using RandomizerLib.Populator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace RandomizerLib
{
    public class Service1 : IService1
    {

        UserDao userDao = new EntityFrameworkUserDao();

        UserDtoToUserPopulator userDtoToUser = new UserDtoToUserPopulator();
        UserToUserDtoPopulator userToUserDto = new UserToUserDtoPopulator();
        UserCredentialsDtoToUserPopulator userCredentialsDtoToUser = new UserCredentialsDtoToUserPopulator();
        HistoryDtoToRequestPopulator historyDtoToRequest = new HistoryDtoToRequestPopulator();

        public UserDto CheckCredentials(UserCredentialsDto user)
        {
            User userToCheck = userCredentialsDtoToUser.populate(user);
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

        public bool IsUserExist(string login)
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

        public ICollection<Request> GetUserHistoryBy(string login)
        {
            return userDao.GetUserHistory(login);
        }

        public void SaveHistory(HistoryDto history)
        {
            Request request = historyDtoToRequest.populate(history);
            userDao.SaveHistory(history.Login, request);
        }
    }
}

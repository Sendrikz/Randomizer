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

        private UserDao userDao = new EntityFrameworkUserDao();

        private UserDtoToUserPopulator userDtoToUser = new UserDtoToUserPopulator();
        private UserToUserDtoPopulator userToUserDto = new UserToUserDtoPopulator();
        private UserCredentialsDtoToUserPopulator userCredentialsDtoToUser = new UserCredentialsDtoToUserPopulator();
        private HistoryDtoToRequestPopulator historyDtoToRequest = new HistoryDtoToRequestPopulator();
        private RequestToRequestDtoPopulator requestToRequestDto = new RequestToRequestDtoPopulator();


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

        public ICollection<RequestDto> GetUserHistoryBy(string login)
        {
            ICollection<Request> requests = userDao.GetUserHistory(login);
            ICollection<RequestDto> dtoRequests = new Collection<RequestDto>();

            foreach (var req in requests)
                dtoRequests.Add(requestToRequestDto.populate(req));

            return dtoRequests;
        }

        public void SaveHistory(HistoryDto history)
        {
            Request request = historyDtoToRequest.populate(history);
            userDao.SaveHistory(history.Login, request);
        }
    }
}

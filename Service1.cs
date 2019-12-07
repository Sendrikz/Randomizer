using NLog;
using RandomizerLib.Dao;
using RandomizerLib.Dto;
using RandomizerLib.Exception;
using RandomizerLib.Model;
using RandomizerLib.Populator;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace RandomizerLib
{
    public class Service1 : IService1
    {

        private Logger logger = LogManager.GetCurrentClassLogger(); 

        private UserDao userDao = new EntityFrameworkUserDao();

        private UserDtoToUserPopulator userDtoToUser = new UserDtoToUserPopulator();
        private UserToUserDtoPopulator userToUserDto = new UserToUserDtoPopulator();
        private UserCredentialsDtoToUserPopulator userCredentialsDtoToUser = new UserCredentialsDtoToUserPopulator();
        private HistoryDtoToRequestPopulator historyDtoToRequest = new HistoryDtoToRequestPopulator();
        private RequestToRequestDtoPopulator requestToRequestDto = new RequestToRequestDtoPopulator();


        public UserDto CheckCredentials(UserCredentialsDto user)
        {
            logger.Info("Check credentials for user: " + user.Login);
            User userToCheck = userCredentialsDtoToUser.Populate(user);
            User resultedUser; 

            try
            {
               resultedUser = userDao.GetLogined(userToCheck);
            }
            catch(System.Exception e)
            {
                logger.Error(e.Message);
                throw new FaultException<NoSuchUserException>(new NoSuchUserException(), e.Message);
            }

            return userToUserDto.Populate(resultedUser);
        }

        public bool IsUserExist(string login)
        {
            logger.Info("Check if exit user with login: " + login);
            try
            {
                userDao.GetUserByLogin(login);
            }
            catch (System.Exception)
            {
                logger.Warn("No user with such login: " + login);
                return false;
            }

            return true;
        }


        public void RegisterUser(UserDto user)
        {
            logger.Info("Register user with login: " + user.Login);
            User userToAdd = userDtoToUser.Populate(user);

            userDao.CreateUser(userToAdd);
        }

        public ICollection<RequestDto> GetUserHistoryBy(string login)
        {
            logger.Info("Get history of user with login: " + login);
            ICollection<Request> requests = userDao.GetUserHistory(login);
            ICollection<RequestDto> dtoRequests = new Collection<RequestDto>();

            foreach (var req in requests)
                dtoRequests.Add(requestToRequestDto.Populate(req));

            return dtoRequests;
        }

        public void SaveHistory(HistoryDto history)
        {
            logger.Info("Save history of user with login: " + history.Login);
            Request request = historyDtoToRequest.Populate(history);

            userDao.SaveHistory(history.Login, request);
        }
    }
}

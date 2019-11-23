using RandomizerLib.Dto;
using RandomizerLib.Exception;
using System.ServiceModel;

namespace RandomizerLib
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool ExistUser(string login);

        [OperationContract]
        void RegisterUser(UserDto user);

        [OperationContract]
        [FaultContract(typeof(NoSuchUserException))]
        UserDto CheckCredentials(UserCredentialsDto user);

        [OperationContract]
        void UserHistory(string login);

        [OperationContract]
        void SaveHistory(HistoryDto history);
    }
  
}

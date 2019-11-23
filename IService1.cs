using RandomizerLib.Dto;
using RandomizerLib.Exception;
using System.ServiceModel;

namespace RandomizerLib
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [FaultContract(typeof(NoSuchUserException))]
        UserDto GetUser(string login);

        [OperationContract]
        bool RegisterUser(UserDto user);

        [OperationContract]
        [FaultContract(typeof(NoSuchUserException))]
        UserDto CheckCredentials(UserCredentialsDto user);
       
    }
  
}

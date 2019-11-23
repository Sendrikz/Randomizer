using RandomizerLib.Dto;
using RandomizerLib.Exception;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RandomizerLib
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        UserDto GetUser(string login);

        [OperationContract]
        bool RegisterUser(UserDto user);

        [OperationContract]
        UserDto CheckCredentials(UserCredentialsDto user);
       
    }
  
}

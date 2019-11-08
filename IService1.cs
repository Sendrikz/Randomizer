using RandomizerLib.Dto;
using RandomizerLib.Exception;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RandomizerLib
{
    [ServiceContract]
    public interface IService1
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        UserDto GetUser(string login);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        HttpStatusCode RegisterUser(UserDto user);

        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(Fault))]
        UserDto CheckCredentials(UserCredentialsDto user);
       
    }
  
}

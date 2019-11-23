using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Exception
{
    [DataContract]
    public class NoSuchUserException
    {

        [DataMember]
        private string Message;

        public NoSuchUserException()
        {
        }

        public NoSuchUserException(string message)
        {
            Message = message;
        }

    }
}

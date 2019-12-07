using System.Runtime.Serialization;

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

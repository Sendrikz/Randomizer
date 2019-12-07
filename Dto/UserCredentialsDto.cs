using System.Runtime.Serialization;

namespace RandomizerLib.Dto
{
    [DataContract]
    public class UserCredentialsDto
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace RandomizerLib.Dto
{
    [DataContract]
    public class RequestDto
    {
        [DataMember]
        public int From { get; set; }

        [DataMember]
        public int To { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
    }
}

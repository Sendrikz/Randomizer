using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

using System.Runtime.Serialization;

namespace RandomizerLib.Dto
{
    [DataContract]
    public class HistoryDto
    {
        [DataMember]
        public int From { get; set; }

        [DataMember]
        public int To { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Login { get; set; }

    }
}

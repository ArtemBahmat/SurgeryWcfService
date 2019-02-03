using System.Runtime.Serialization;

namespace TestLibrary.Models
{
    [DataContract]
    public class DtReqMdl
    {
        [DataMember]
        public string ClientId { get; set; }
    }
}

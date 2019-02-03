using System.Runtime.Serialization;
using Newtonsoft.Json;
using TestLibrary.CustomJsonConverters;

namespace TestLibrary.Models
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string VersionId { get; set; }

        [DataMember]
        public bool IsDeactivated { get; set; }

        [DataMember]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool IsTestApprovalProcess { get; set; }
    }
}

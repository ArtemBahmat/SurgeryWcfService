using System.Runtime.Serialization;

namespace TestLibrary.Models
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string TypeId { get; set; }

        [DataMember]
        public string VersionId { get; set; }

        [DataMember]
        public string ReferenceId { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}

using System.Runtime.Serialization;

namespace TestLibrary.Models
{
    [DataContract]
    public class SysState
    {
        public SysState() {}

        public SysState(string stateCode)
        {
            StateCode = stateCode;
        }

        [DataMember]
        public string StateCode { get; set; }
    }
}

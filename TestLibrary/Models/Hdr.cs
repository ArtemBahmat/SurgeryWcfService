using Newtonsoft.Json;

namespace TestLibrary.Models
{
    public class Hdr
    {
        [JsonProperty("Guid_TestCode")]
        public int TestCode { get; set; }

        [JsonProperty("Guid_SpecimenID")]
        public int SpecimenId { get; set; }

        [JsonProperty("Date_Collected")]
        public string DateCollected { get; set; }

        public string SelTests { get; set; }

        [JsonProperty("Guid_ClientID")]
        public string ClientId { get; set; }
    }
}

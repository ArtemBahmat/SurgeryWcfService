using Newtonsoft.Json;
using TestLibrary.CustomJsonConverters;

namespace TestLibrary.Models
{
    public class SelTest
    {
        [JsonProperty("Specimen_Num")]
        public string SpecimenNum { get; set; }

        [JsonProperty("Guid_TestCode")]
        public string TestCode { get; set; }

        [JsonProperty("Flag_Allowed")]
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool IsAllowed { get; set; }
    }
}

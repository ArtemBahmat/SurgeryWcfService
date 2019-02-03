using Newtonsoft.Json;

namespace TestLibrary.Models
{
    public class SurgicalDt
    {
        [JsonProperty("RowIndex")]
        public int RowIndex { get; set; }

        [JsonProperty("SpecimenNum")]
        public string SpecimenNum { get; set; }

        [JsonProperty("Path_SpecimenCase")]
        public string PathSpecimenCase { get; set; }

        public string Site { get; set; }

        public string Location { get; set; }

        [JsonProperty("PID")]
        public string PId { get; set; }

        [JsonProperty("SMCodeID")]
        public string SmCodeId { get; set; }

        [JsonProperty("SMComments")]
        public string SmComments { get; set; }

        public string Discrepancy { get; set; }

        [JsonProperty("SerializeDiscrInfo")]
        public string SerializeDiscrepancyInfo { get; set; }
    }
}

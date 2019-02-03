using Newtonsoft.Json;

namespace TestLibrary.Models
{
    public class SelDiscrepancy
    {
        [JsonProperty("Rejection_ID")]
        public string RejectionId { get; set; }

        [JsonProperty("Txt_AddMsg")]
        public string AddMsg { get; set; }
    }
}

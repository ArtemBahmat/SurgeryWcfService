namespace BLL.Models
{
    public class ClientDto
    {
        public string Id { get; set; }

        public string VersionId { get; set; }

        public bool IsDeactivated { get; set; }

        public bool IsTestApprovalProcess { get; set; }
    }
}

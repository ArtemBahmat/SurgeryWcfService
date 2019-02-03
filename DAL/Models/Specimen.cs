namespace DAL.Models
{
    public class Specimen
    {
        public string Num { get; set; }

        public string PathCase { get; set; }

        public bool IsOnePId { get; set; }

        public string SmRejectionId { get; set; }

        public string SlRejectionId { get; set; }

        public string SsRejectionId { get; set; }

        public string SmComments { get; set; }
    }
}

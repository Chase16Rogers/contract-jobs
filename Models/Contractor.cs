namespace contract_job.Models
{
    public class Contractor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }

    public class ContractorJobView : Contractor
    {
        public int contractJobId { get; set; }
    }
}
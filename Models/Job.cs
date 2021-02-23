namespace contract_job.Models
{
    public class Job
    {
        public int id { get; set; }
        public string task { get; set; }
        public float rate { get; set; }
    }

    public class JobContractorView : Job
    {
        public int contractJobId { get; set; }
    }
}
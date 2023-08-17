namespace ProjectUpdateApp.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public bool IsDelete { get; set; }

    }
}

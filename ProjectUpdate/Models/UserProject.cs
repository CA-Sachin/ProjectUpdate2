namespace ProjectUpdateApp.Models
{
    public class UserProject
    {
        public Guid  UserProjectid { get; set; }

        public Guid Userid { get; set; }
        public Guid Projectid{ get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDelete { get; set; }


    }
}

namespace ProjectUpdateApp.Models
{
    public class UserRole
    {
        public Guid UserRoleid { get; set; }
        public Guid Userid { get; set; }
        public Guid Roleid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDelete { get; set; }
    }
}
